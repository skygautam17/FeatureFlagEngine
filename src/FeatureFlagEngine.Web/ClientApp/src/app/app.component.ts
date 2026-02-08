
import { Component } from '@angular/core';

@Component({
  selector:'app-root',
  template:`
    <h1>Feature Flag Admin</h1>
    <app-feature-material-table></app-feature-material-table>
    <app-feature-list></app-feature-list>
  `
})
export class AppComponent {}
