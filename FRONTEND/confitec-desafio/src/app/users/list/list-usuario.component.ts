import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-list-usuario',
  templateUrl: './list-usuario.component.html',
  styleUrls: ['./list-usuario.component.css']
})
export class ListUsuarioComponent implements OnInit {

  listUsers: any[] = [];
  constructor(private usuarioService: UsuarioService, private router: Router) { }

  ngOnInit(): void {        
    this.chargeListPeople();
  }

  async chargeListPeople() {
    this.usuarioService.BuscarTodos().subscribe(x => {
      this.listUsers = x
    });
    this.listUsers;
  }

  removeUsuario(id: number) {
    this.usuarioService.RemoverUsuario(id).subscribe(() => {
      window.location.reload();
    }, err => { console.log(err); });
  }

}
