import { Component, OnInit } from '@angular/core';
import { TituloComponent } from "../../shared/titulo/titulo.component";
import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-empresas',
  imports: [CommonModule, TituloComponent, NgxSpinnerModule, RouterOutlet],
  templateUrl: './empresas.component.html',
  styleUrl: './empresas.component.scss'
})
export class EmpresasComponent{
  
}
