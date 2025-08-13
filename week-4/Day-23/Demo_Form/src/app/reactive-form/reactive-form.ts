import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgIf } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import FormsModule and
import { NgForm } from '@angular/forms'; // Import NgForm for template-driven forms, if needed

@Component({
  selector: 'app-reactive-form',
  imports: [NgIf, CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './reactive-form.html',
  styleUrl: './reactive-form.css',
})
export class ReactiveFormComponent {
  userForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    email: new FormControl('', [Validators.required, Validators.email]),
  });

  onSubmit() {
    if (this.userForm.valid) {
      console.log('Reactive Form Submitted:', this.userForm.value);
      this.userForm.reset();
    } else {
      this.userForm.markAllAsTouched(); //Marks every control in the form as if the user has interacted with them
      // so angular validation state touched becomes true for each conrol
    }
  }

  // helpers for template
  get name() {
    return this.userForm.get('name');
  }
  get email() {
    return this.userForm.get('email');
  }
}
