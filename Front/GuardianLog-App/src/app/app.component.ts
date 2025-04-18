import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from './shared/nav/nav.component';
import { FooterComponent } from "./shared/footer/footer.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GuardianLog-App';
}
