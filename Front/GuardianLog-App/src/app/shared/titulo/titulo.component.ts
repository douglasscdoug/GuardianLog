import { Component, Input, input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-titulo',
  imports: [RouterLink],
  templateUrl: './titulo.component.html',
  styleUrl: './titulo.component.scss'
})
export class TituloComponent {
  @Input() titulo: string = '';
  @Input() iconClass: string = 'fa fa-user';

}
