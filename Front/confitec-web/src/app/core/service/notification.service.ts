import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject } from 'rxjs';
import { NotificationMessage } from '../model/notification-message.model';

const Noty = require('noty');

@Injectable({
    providedIn: 'root'
})
export class NotificationService {

    notificationErrorDispatcher: Subject<NotificationMessage> = new Subject<NotificationMessage>();
    notifications: any[] = [];
    notificationAdded: BehaviorSubject<any> = new BehaviorSubject<any>(null);
    notificationRemoved: BehaviorSubject<any> = new BehaviorSubject<any>(null);

    constructor() {
        this.notificationErrorDispatcher.subscribe(e => this.showError(e));
    } 

    dispatchError(error: NotificationMessage): void {
        this.notificationErrorDispatcher.next(error);
    }

    showSuccess(message: NotificationMessage): void {
        if (!message || !message.mensagem) {
            return;
        }
        message.MessageType = 'success';
        this.notify(message);
    }

    showError(error: NotificationMessage): void {

      if (!error) {
        return;
      }


      if (error.error && error.error.error === 'invalid_grant' && error.error.error_description &&
      error.error.error_description === 'invalid_username_or_password') {
        error.mensagem = 'Login ou senha inválidos.';
      }

      error.MessageType = 'error';

      if (!error.mensagem) {
        error.mensagem = 'Ocorreu um erro inesperado, por favor tente novamente.';
      }
      this.notify(error);
    }

    notify(message: NotificationMessage): void {

        if (!message || !message.mensagem) {
            return;
        }

        new Noty({
            type: message.MessageType ? message.MessageType : 'info',
            layout: 'topRight',
            theme: 'mint',
            text: message.mensagem,
            timeout:  4000,
            progressBar: true,
            closeWith: ['click'],
            animation: {
                open: 'noty_effects_open',
                close: 'noty_effects_close'
            },
            id: false,
            force: false,
            killer: false,
            queue: 'global',
            container: false,
            buttons: [],
            sounds: {
                sources: [],
                volume: 1,
                conditions: []
            },
            titleCount: {
                conditions: []
            },
            modal: false
        }).show();
    }

    add(key: string, message: string, type: number): any {

        if (this.notifications.filter(n => n.key == key).length) {
            return;
        }

        const notificacao = {
            key,
            message,
            type,
            read: false
        };
        this.notifications.push(notificacao);
        this.notificationAdded.next(notificacao);
        return notificacao;
    }

    remove(key: string): void {
        const arr = this.notifications.filter(n => n.key === key);

        if (!arr || !arr.length) {
            return;
        }

        const notification = arr[0];
        const i = this.notifications.indexOf(notification);

        if (i === -1) {
            return;
        }

        this.notifications.splice(i, 1);
        this.notificationRemoved.next(notification);
    }

}
