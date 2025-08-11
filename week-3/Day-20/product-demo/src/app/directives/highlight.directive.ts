import {
  Directive,
  ElementRef,
  HostListener,
  Input,
  Renderer2,
} from '@angular/core';

@Directive({
  selector: '[appHighlight]',
})
export class HighlightDirective {
  @input('appHighlight') highlightColor: string = 'yellow';
  private originalBackground: string | null = '';
  constructor(private el: ElementRef, private renderer: Renderer2) {
    this.originalBackground = this.el.nativeElement.style.backgroundColor || '';
  }
  // mouse enter hover effect
  @HostListener('mouseenter') onEnter() {
    this.renderer.setStyle(
      this.el.nativeElement,
      'backgroundColor',
      this.highlightColor
    );
    this.renderer.setStyle(this.el.nativeElement, 'cursor', 'pointer');
    this.renderer.setStyle(
      this.el.nativeElement,
      'transition',
      'background-color 0.3s ease'
    );
  }
  // mouse leave hover effect
  @HostListener('mouseleave') onMouseLeave() {
    this.renderer.setStyle(
      this.el.nativeElement,
      'backgroundColor',
      this.originalBackground
    );
    this.renderer.setStyle(this.el.nativeElement, 'cursor', 'default');
    this.renderer.setStyle(
      this.el.nativeElement,
      'transition',
      'background-color 0.3s ease'
    );
  }
  // using renderer to avoids direct DOM manipulation
  // Hostlisste=ner reacts to user events like mouseenter and mouseleave
}
