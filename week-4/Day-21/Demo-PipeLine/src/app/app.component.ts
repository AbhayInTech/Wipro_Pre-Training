import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { StyledCardComponent } from './styled-card/styled-card.component';
import { ScopeStylingComponent } from './scope-styling/scope-styling.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    StyledCardComponent,
    ScopeStylingComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'Demo-PipeLine';
}
