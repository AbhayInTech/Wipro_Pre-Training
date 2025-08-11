import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LifecycleDemoComponent } from './lifecycle-demo/lifecycle-demo.component';
import { ParentComponent } from './parent/parent.component';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LifecycleDemoComponent, ParentComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Lifecycle_hooks_Demo';
}
