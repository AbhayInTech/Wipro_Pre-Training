import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormComponent } from './reactive-form/reactive-form';
import { TemplateFormComponent } from './template-form/template-form'; // Keep this import
import { CommonModule } from '@angular/common'; // Import CommonModule
import { ReactiveFormsModule } from '@angular/forms'; // Import ReactiveFormsModule

@Component({
  selector: 'app-root',
  templateUrl: './app.html', // Use app.html for the template
  imports: [
    ReactiveFormComponent,
    TemplateFormComponent,
    CommonModule,
    ReactiveFormsModule,
  ], // Add CommonModule and ReactiveFormsModule
  standalone: true,
  styles: [],
})
export class App {}
