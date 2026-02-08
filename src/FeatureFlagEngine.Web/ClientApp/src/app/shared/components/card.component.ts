import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  standalone: true,
  template: `
    <div style="border:1px solid #ddd;padding:16px;margin:10px 0;border-radius:8px;">
      <ng-content></ng-content>
    </div>
  `
})
export class CardComponent {}
