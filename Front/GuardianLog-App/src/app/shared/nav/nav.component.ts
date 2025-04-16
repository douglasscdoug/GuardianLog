import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Component, HostListener, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, RouterLink, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  public isMenuOpen = false;

  constructor() { }

  ngOnInit() {
  }

  @HostListener('document: click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    const clickedElement = event.target as HTMLElement;
    const offcanvas = document.querySelector('.offcanvas');
    const toggler = document.querySelector('.navbar-toggler');

    if(
      this.isMenuOpen &&
      offcanvas &&
      !offcanvas.contains(clickedElement) &&
      toggler &&
      !toggler.contains(clickedElement)
    ){
      this.isMenuOpen = false;
    }
  }

}
