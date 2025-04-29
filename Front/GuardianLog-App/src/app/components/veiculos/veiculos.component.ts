import { Component } from '@angular/core';
import { TituloComponent } from "../../shared/titulo/titulo.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-veiculos',
  imports: [TituloComponent, RouterOutlet],
  templateUrl: './veiculos.component.html',
  styleUrl: './veiculos.component.scss'
})
export class VeiculosComponent {

}
