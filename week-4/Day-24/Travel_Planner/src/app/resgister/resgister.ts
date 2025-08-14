import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-resgister',
  imports: [ReactiveFormsModule],
  templateUrl: './resgister.html',
  styleUrl: './resgister.css',
})
export class Resgister {
  registerForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    confirmPassword: new FormControl(''),
  });
  onSubmit() {
    console.log(this.registerForm.value);
  }
  onClick() {
    console.log(this.registerForm.value);
  }
}
