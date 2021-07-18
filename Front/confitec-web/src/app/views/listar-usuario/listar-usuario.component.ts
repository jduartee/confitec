import { Component, OnInit } from '@angular/core';
import { faSearch, faUserEdit, faUserPlus, faUserTimes } from '@fortawesome/free-solid-svg-icons';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmDialogComponent } from 'src/app/core/components/confirm-dialog.component';
import { listarUsuarioDTO } from 'src/app/core/model/usuario/listarUsuarioDTO';
import { EscolaridadeService } from 'src/app/core/service/escolaridade.service';
import { UsuarioService } from 'src/app/core/service/usuario.service';

@Component({
  selector: 'app-listar-usuario',
  templateUrl: './listar-usuario.component.html',
  styleUrls: ['./listar-usuario.component.css']
})
export class ListarUsuarioComponent implements OnInit {
  nome: string = "";
  escolaridadeId: number = 0;
  lista: Array<listarUsuarioDTO> = [];
  usuarioId : number = 0;

  listarEscolaridade: any;
  closeResult = '';

  editUserIcon = faUserEdit;
  removeUserIcon = faUserTimes;
  searchIcon = faSearch;
  addUserIcon = faUserPlus;

  constructor(private usuarioService: UsuarioService, 
              private escolaridadeService: EscolaridadeService, 
              private modalService: NgbModal) { }

  ngOnInit(): void {
    
    this.obterUsuarios();    
    
    this.escolaridadeService.listar().subscribe(res => {
      this.listarEscolaridade = res;
    });
  }

  obterUsuarios(){
    this.usuarioService.listar(this.nome).subscribe(res => {
      this.lista = res;
    });
  }

  open(content: any,id : number) {

    this.usuarioId = id;

    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }  

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  onDismissModal(){
    this.modalService.dismissAll();
  }

  excluirUsuario(){
    
    const modalRef = this.modalService.open(ConfirmDialogComponent);
    modalRef.componentInstance.message = "Tem certeza que deseja excluir este usúario?";
    modalRef.componentInstance.header = "Excluir usúario."
      modalRef.result.then(() => {
        console.log('test')
        // this.acaoConquistaService
        //   .deletarAcaoConquista(acaoConquistaId)
        //   .subscribe((x) => {
        //     var indice = this.acaoConquista.indexOf(acaoConquista);
        //     this.acaoConquista.splice(indice, 1);

        //     this.notificationService.showSuccess(
        //       new NotificationMessage({
        //         mensagem: "Ação excluída com sucesso!",
        //       })
        //     );
        //   });
      });
  }


}
