import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { salvarUsuarioDTO } from "../model/usuario/salvarUsuarioDTO";
import { listarUsuarioDTO } from "../model/usuario/listarUsuarioDTO";

@Injectable({ providedIn: 'root' })
export class UsuarioService  {
    baseUrl = "https://localhost:44307/api/";

    constructor(
      protected http: HttpClient) {
    }

    obter(id: number): Observable<salvarUsuarioDTO> {
        return this.http.get<salvarUsuarioDTO>(`${this.baseUrl}Usuario/listar-usuarios/${id}`);
    }

    listar(nome: string, escolaridadeId: number): Observable<listarUsuarioDTO[]>{
        let filtro= "";

        return this.http.get<listarUsuarioDTO[]>(`${this.baseUrl}Usuario/listar-usuarios?NomeCompleto=${nome}&EscolaridadeId=${escolaridadeId}`);
    }

    incluir(salvarUsuarioDTO: salvarUsuarioDTO ): Observable<any>{
        return this.http.post(`${this.baseUrl}Usuario/incluir-usuario`, salvarUsuarioDTO);
    }

    alterar(salvarUsuarioDTO: salvarUsuarioDTO ): Observable<any>{
        return this.http.put(`${this.baseUrl}Usuario/alterar-usuario/${salvarUsuarioDTO.id}`, salvarUsuarioDTO);
    }

    deletar(id: number): Observable<any>{
        return this.http.delete(`${this.baseUrl}Usuario/deletar-usuario/${id}`);
    }
}