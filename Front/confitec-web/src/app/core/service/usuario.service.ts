import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { salvarUsuarioDTO } from "../model/usuario/salvarUsuarioDTO";
import { listarUsuarioDTO } from "../model/usuario/listarUsuarioDTO";

@Injectable({ providedIn: 'root' })
export class UsuarioService  {
    baseUrl = "https://localhost:44307/";

    constructor(
      protected http: HttpClient) {
    }

    obter(id: number): Observable<salvarUsuarioDTO> {
        return this.http.get<salvarUsuarioDTO>(`${this.baseUrl}Usuario/listar-usuarios/${id}`);
    }

    listar(nome: string): Observable<listarUsuarioDTO[]>{
        return this.http.get<listarUsuarioDTO[]>(`${this.baseUrl}Usuario/listar-usuarios`);
    }

    incluir(salvarUsuarioDTO: salvarUsuarioDTO ): Observable<any>{
        return this.http.post(`${this.baseUrl}Usuario/incluir-usuario`, salvarUsuarioDTO);
    }

    alterar(salvarUsuarioDTO: salvarUsuarioDTO ): Observable<any>{
        return this.http.put(`${this.baseUrl}Usuario/alterar-usuario/${salvarUsuarioDTO.id}`, salvarUsuarioDTO);
    }




}