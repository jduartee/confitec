import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'ngbd-modal-confirm',
  template: `
  <div class="modal-header">
    <h4 class="modal-title" id="modal-title">{{header}}</h4>   
  </div>
  <div class="modal-body">
    <p>{{message}}</p>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-outline-danger" (click)="modal.dismiss()">Não</button>
    <button type="button" class="btn btn-outline-primary" (click)="modal.close()">Sim</button>
  </div>
  `
})
export class ConfirmDialogComponent {
  @Input() message: any;
  @Input() header: any;
  constructor(public modal: NgbActiveModal) {}
}
