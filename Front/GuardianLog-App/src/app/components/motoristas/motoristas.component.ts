import { Component } from '@angular/core';
import { TituloComponent } from "../../shared/titulo/titulo.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-motoristas',
  imports: [TituloComponent, RouterOutlet],
  templateUrl: './motoristas.component.html',
  styleUrl: './motoristas.component.scss'
})
export class MotoristasComponent {

}
