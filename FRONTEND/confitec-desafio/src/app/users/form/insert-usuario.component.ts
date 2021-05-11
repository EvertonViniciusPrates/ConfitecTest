import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../model/usuario';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-insert-usuario',
  templateUrl: './insert-usuario.component.html',
  styleUrls: ['./insert-usuario.component.css']
})
export class InsertUsuarioComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuarioService, private router: Router, private route: ActivatedRoute) { }

  form: FormGroup;
  usuario: Usuario;
  id = this.route.snapshot.queryParams['id'];
  ngOnInit(): void {
    this.initializeForm();
    if(this.id > 0){
      this.carregaFormUpdate(); 
    }
  }

  carregaFormUpdate(){
    this.usuarioService.BuscarPorId(this.id).subscribe(x => {
      this.form = this.formBuilder.group({
        id: x.result.id,
        nome: x.result.nome,
        sobrenome: x.result.sobrenome,
        email: x.result.email,
        dataNascimento: x.result.dataNascimento,
        escolaridadeId: x.result.escolaridadeId
      });
    });    
  }

  initializeForm(): void {
    this.form = this.formBuilder.group({
      id: [null],
      nome: [null, Validators.required],
      sobrenome: [null, Validators.required],
      email: [null, Validators.required],
      dataNascimento: [null, Validators.required],
      escolaridadeId: [null, Validators.required]
    });
  }

  public processInfo(): void {
    let dadosForm = this.form.value;
    this.usuario = {
      id: dadosForm.id,
      nome: dadosForm.nome,
      sobrenome: dadosForm.sobrenome,
      email: dadosForm.email,
      dataNascimento: dadosForm.dataNascimento,
      escolaridadeId: parseInt(dadosForm.escolaridadeId)
    }
    if (this.form.valid) {
      this.save(this.usuario);
    }
  }

  private save(usuario: Usuario): void {
    this.usuarioService.Salvar(usuario).subscribe(() => {
      this.router.navigate(['listar']);
    }, err => { console.log(err); });
  }

}

