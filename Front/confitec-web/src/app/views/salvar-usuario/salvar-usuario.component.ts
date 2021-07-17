import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { faCalendarAlt, faCheck } from '@fortawesome/free-solid-svg-icons';
import { salvarUsuarioDTO } from 'src/app/core/model/usuario/salvarUsuarioDTO';

@Component({
  selector: 'app-salvar-usuario',
  templateUrl: './salvar-usuario.component.html',
  styleUrls: ['./salvar-usuario.component.css']
})
export class SalvarUsuarioComponent implements OnInit {

  @Input() listarEscolaridade: any;
  @Input() salvarUsuarioDTO!: salvarUsuarioDTO;
  @Output() dismissModal = new EventEmitter();

  calendarIcon = faCalendarAlt
  checkIcon = faCheck

  usuarioForm : FormGroup = new FormGroup({
      id: new FormControl('', Validators.required),
      nome: new FormControl('', Validators.required),
      sobrenome: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      dataNascimento : new FormControl(''),
      escolaridadeId: new FormControl('')
    })

  constructor() { }

  ngOnInit(): void {
  }


  dismiss(){

    

    this.dismissModal.emit(null);
  }
}
