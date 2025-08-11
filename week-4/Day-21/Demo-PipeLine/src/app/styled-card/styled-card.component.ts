import { Component } from '@angular/core';

@Component({
  selector: 'app-styled-card',
  imports: [],
  templateUrl: './styled-card.component.html',
  styleUrl: './styled-card.component.css',
  styles: [
    `
      .styled-card {
        background-color: #f9f9f9;
        border: 1px solid #ddd;
      }
    `,
  ],
})
export class StyledCardComponent {}
