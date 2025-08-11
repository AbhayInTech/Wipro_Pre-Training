import { Component, OnInit, OnChanges, OnDestroy, Input } from '@angular/core';

@Component({
  selector: 'app-lifecycle-demo',
  imports: [],
  templateUrl: './lifecycle-demo.component.html',
  styleUrl: './lifecycle-demo.component.css',
})
export class LifecycleDemoComponent implements OnInit, OnChanges, OnDestroy {
  @Input() title!: string;

  constructor() {
    console.log(
      '1.Constructor is Invoked : componenet instance is created ...'
    );
  }

  ngOnInit(): void {
    console.log('2.Constructor : component instance is created ...');
  }

  ngOnChanges(): void {
    console.log('3.ngOnInit :Component Initialized');
  }

  ngOnDestroy(): void {
    console.log('4.ngOnDestroy is Invoked : component is destroyed ...');
  }
}
