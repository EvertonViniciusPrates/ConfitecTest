import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../model/usuario';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private httpClient: HttpClient) { }

  public Salvar(usuario: Usuario){
    return this.httpClient.post('https://localhost:44338/api/usuario', usuario);
  }
  public BuscarTodos(){
    return this.httpClient.get<any[]>("https://localhost:44338/api/usuario").pipe(map(x => x));
  }
  public RemoverUsuario(id: number){
    return this.httpClient.delete('https://localhost:44338/api/usuario/' + id);
  }

  public BuscarPorId(id: number){
    return this.httpClient.get<any>('https://localhost:44338/api/usuario/' + id);
  }
}
