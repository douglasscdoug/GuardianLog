import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public login = '';
  public password = '';
  public errorMessage = '';

  constructor() { }

  ngOnInit() {
  }

  public entrar() {
    if (!this.login || !this.password) {
      this.errorMessage = 'Por favor, preencha todos os campos.';
      return;
    }

    console.log('Tentando logar com:', this.login, this.password);
    this.errorMessage = '';
  }
}
