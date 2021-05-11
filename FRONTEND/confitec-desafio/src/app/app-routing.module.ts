import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InsertUsuarioComponent } from './users/form/insert-usuario.component';
import { ListUsuarioComponent } from './users/list/list-usuario.component';

const routes: Routes = [
  {path: 'inserir', component: InsertUsuarioComponent},
  {path: 'listar', component: ListUsuarioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
