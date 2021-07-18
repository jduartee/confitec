import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { faCalendarAlt, faCheck } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertDialogComponent } from 'src/app/core/components/alert-dialog';
import { UsuarioService } from 'src/app/core/service/usuario.service';
import { invalidDateValidator } from 'src/shared/invalid-date.directive';

@Component({
  selector: 'app-salvar-usuario',
  templateUrl: './salvar-usuario.component.html',
  styleUrls: ['./salvar-usuario.component.css']
})
export class SalvarUsuarioComponent implements OnInit {

  @Input() listarEscolaridade: any;
  @Input() usuarioId: number = 0;
  @Output() dismissModal = new EventEmitter();
  @Output() atualizarLista = new EventEmitter();

  calendarIcon = faCalendarAlt
  checkIcon = faCheck

  usuarioForm : FormGroup = new FormGroup({
      id: new FormControl('0', Validators.required),
      nome: new FormControl('', Validators.required),
      sobrenome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      dataNascimento : new FormControl('', [Validators.required]),
      escolaridadeId: new FormControl('', Validators.required)
    })

  constructor(private usuarioService: UsuarioService,
              private modalService: NgbModal) { }

  ngOnInit(): void {
    console.log(new Date())
    this.obterUsuario();
  }

  onSubmit() {
    var usuarioDTO = this.usuarioForm.value;

    if(new Date( usuarioDTO.dataNascimento) >  new Date()){
      const modalRef = this.modalService.open(AlertDialogComponent);
                  modalRef.componentInstance.message = "Data de nascimento não pode ser superior a data atual.";
                  modalRef.componentInstance.header = "Atenção."
    }

return;

    if(usuarioDTO.id > 0){
      this.usuarioService.alterar(usuarioDTO).toPromise().then(resp=>{
        this.atualizarLista.emit(null);
        this.dismiss();

        const modalRef = this.modalService.open(AlertDialogComponent);
                  modalRef.componentInstance.message = "Usúario alterado com sucesso.";
                  modalRef.componentInstance.header = "Atenção."
      })
    }else{
      this.usuarioService.incluir(usuarioDTO).toPromise().then(resp=>{
        this.atualizarLista.emit(null);
        this.dismiss();

        
        const modalRef = this.modalService.open(AlertDialogComponent);
                  modalRef.componentInstance.message = "Usúario incluido com sucesso.";
                  modalRef.componentInstance.header = "Atenção."
      })
    }
  }

  dismiss(){
    this.dismissModal.emit(null);
  }

  obterUsuario(){
    if(this.usuarioId > 0){
      this.usuarioService.obter(this.usuarioId).subscribe(result=> {
          this.usuarioForm.patchValue(result);
      });
    }
  }
}
