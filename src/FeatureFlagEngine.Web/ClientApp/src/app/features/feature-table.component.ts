
import { Component } from '@angular/core';

@Component({
  selector: 'app-feature-table',
  template: `
    <h2>Feature Flags</h2>

    <table border="1">
      <tr>
        <th>Key</th>
        <th>Description</th>
        <th>Enabled</th>
      </tr>
      <tr *ngFor="let f of features">
        <td>{{f.key}}</td>
        <td>{{f.description}}</td>
        <td>{{f.enabled}}</td>
      </tr>
    </table>

    <button (click)="next()">Next Page</button>
  `
})
export class FeatureTableComponent {
  features:any[] = [];
  page = 1;

  next(){
    this.page++;
    console.log("Pagination stub, page:", this.page);
  }
}
