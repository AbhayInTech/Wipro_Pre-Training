import { NgStyle } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-interpolation',
  imports: [NgStyle],
  templateUrl: './interpolation.html',
  styleUrl: './interpolation.css',
})
export class Interpolation {
  f_name: string = 'Abhay';
  age: number = 20;
  L_name: string = 'Rana';
  show: boolean = false;
  text: string = '';

  toggleData() {
    this.show = !this.show;
  }
  showData(event: Event) {
    this.text = (event.target as HTMLInputElement).value;
    console.log(this.text);
    if (this.text == '') {
      (event.target as HTMLInputElement).value = 'no data';
    }
  }
}
