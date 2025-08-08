import { Component } from '@angular/core';

@Component({
  // here we are defining a component
  selector: 'app-hello', // it defines how the component will be used in templates
  imports: [],
  templateUrl: './hello.component.html', // it specifies the HTML associated with the component
  styleUrl: './hello.component.css', // it specifies the CSS associated with the component
})
export class HelloComponent {
  // This is the class for the component
  // You can define properties and methods here that will be used in the template
  message: string = 'Hello, Angular!';

  // constructor() {
  //   // Initialization logic can go here
  // }
}
