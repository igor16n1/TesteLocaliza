import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioPosicaoDTO } from '../DTO/usuario-posicao-dto';
import { UsuarioAmigosDTO } from '../DTO/usuario-amigos-dto';
import { AmigoDTO } from '../DTO/amigo-dto';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  private url = 'https://localhost:44322/api/Usuario/'; 
  constructor(private http: HttpClient) { }

  ConsultarTodosUsuarios (): Observable<UsuarioPosicaoDTO[]> {
    return this.http.get<UsuarioPosicaoDTO[]>(this.url);
  }
  ConsultarUsuarioAmigos (usuarioID: number): Observable<UsuarioAmigosDTO[]> {
    return this.http.get<UsuarioAmigosDTO[]>(this.url + "/" + usuarioID.toString());
  }
  ConsultarAmigosPosicoes(usuarioID: number, usuarioAmigoID: number)
  {
    return this.http.get<AmigoDTO[]>(this.url + "/" + usuarioID.toString() + "/" + usuarioAmigoID.toString());
  }
}
