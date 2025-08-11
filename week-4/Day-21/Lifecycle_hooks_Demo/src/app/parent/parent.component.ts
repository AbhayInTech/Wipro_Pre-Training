import { Component } from '@angular/core';

@Component({
  selector: 'app-parent',
  imports: [],
  templateUrl: './parent.component.html',
  styleUrl: './parent.component.css',
})
export class ParentComponent {
  parentTitle: string = 'Parent Component Title';
  changeTitle() {
    this.parentTitle = 'This Changes at ' + new Date().toLocaleTimeString();
  }
  removeChild() {
    this.parentTitle = '';
  }
}
