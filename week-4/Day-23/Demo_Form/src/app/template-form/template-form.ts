import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgIf } from '@angular/common';
import { NgForm } from '@angular/forms';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-template-form',
  imports: [NgIf, CommonModule, FormsModule],
  templateUrl: './template-form.html',
  styleUrl: './template-form.css',
})
export class TemplateFormComponent {
  // backing model is optional; using formRef.value in submit handler
  onSubmit(formRef: NgForm) {
    console.log('Template Form Submitted:', formRef.value);
    formRef.reset(); // optional
  }
}
