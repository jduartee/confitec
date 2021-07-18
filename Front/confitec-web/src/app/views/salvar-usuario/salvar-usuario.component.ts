import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faCalendarAlt, faCheck } from '@fortawesome/free-solid-svg-icons';
import { regExpEscape } from '@ng-bootstrap/ng-bootstrap/util/util';
import { salvarUsuarioDTO } from 'src/app/core/model/usuario/salvarUsuarioDTO';
import { UsuarioService } from 'src/app/core/service/usuario.service';

@Component({
  selector: 'app-salvar-usuario',
  templateUrl: './salvar-usuario.component.html',
  styleUrls: ['./salvar-usuario.component.css']
})
export class SalvarUsuarioComponent implements OnInit {

  @Input() listarEscolaridade: any;
  @Input() usuarioId: number = 0;
  @Output() dismissModal = new EventEmitter();

  calendarIcon = faCalendarAlt
  checkIcon = faCheck

  usuarioForm : FormGroup = new FormGroup({
      id: new FormControl('0', Validators.required),
      nome: new FormControl('', Validators.required),
      sobrenome: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      dataNascimento : new FormControl(''),
      escolaridadeId: new FormControl('')
    })

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.obterUsuario();
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.usuarioForm.value);

    var usuarioDTO = this.usuarioForm.value;

    if(usuarioDTO.id > 0){
      this.usuarioService.alterar(usuarioDTO).toPromise().then(resp=>{
        console.log('alterado com sucesso')
      })
    }else{
      this.usuarioService.incluir(usuarioDTO).toPromise().then(resp=>{
        console.log('incluido com sucesso')
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
