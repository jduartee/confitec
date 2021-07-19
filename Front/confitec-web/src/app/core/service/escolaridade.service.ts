import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class EscolaridadeService  {
    baseUrl = "https://localhost:44307/api/";

    constructor(
      protected http: HttpClient) {
    }

    listar(): Observable<any>{
        return this.http.get(`${this.baseUrl}Escolaridade/obter-escolaridade-ativa`);
    }
}