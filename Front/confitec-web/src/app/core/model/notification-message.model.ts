export class NotificationMessage {

    constructor(options?: any) {
        if (options) {
            Object.assign(this, options);
        }
    }
  
    MessageType?: string;
    Timeout?: number;
    errors: any;
    mensagem: any;
    error: any;
  }
  