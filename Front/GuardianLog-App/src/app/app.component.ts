import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './shared/nav/nav.component';
import { FooterComponent } from "./shared/footer/footer.component";
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavComponent, FooterComponent, NgxSpinnerModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GuardianLog-App';
  constructor(private localeService: BsLocaleService) {
    this.localeService.use('pt-br');
  }
}
