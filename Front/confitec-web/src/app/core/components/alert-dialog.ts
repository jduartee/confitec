import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'ngbd-modal-alert',
  template: `
  <div class="modal-header">
    <h4 class="modal-title" id="modal-title">{{header}}</h4>
  </div>
  <div class="modal-body">
    <p>{{message}}</p>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-primary" (click)="modal.close()">Sim</button>
  </div>
  `
})
export class AlertDialogComponent {
  @Input() message: any;
  @Input() header: any;
  constructor(public modal: NgbActiveModal) {}
}
