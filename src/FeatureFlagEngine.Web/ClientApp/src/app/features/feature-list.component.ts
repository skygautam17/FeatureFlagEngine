import { Component, OnInit } from '@angular/core';
import { Feature, FeatureService } from '../services/feature.service';

@Component({
    selector: 'app-feature-list',
    template: `
  <h2>Features</h2>

  <form (ngSubmit)="add()">
    <input [(ngModel)]="key" name="key" placeholder="Key" required />
    <input [(ngModel)]="description" name="description" placeholder="Description" />
    <label>
      <input type="checkbox" [(ngModel)]="enabled" name="enabled" /> Enabled
    </label>
    <button type="submit">Add</button>
  </form>

  <ul>
    <li *ngFor="let f of features">
      {{f.key}} - {{f.enabled}}
      <button (click)="remove(f.id)">Delete</button>
    </li>
  </ul>
  `
})
export class FeatureListComponent implements OnInit {

    features: Feature[] = [];
    key = '';
    description = '';
    enabled = false;

    constructor(private service: FeatureService) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.service.getAll().subscribe(x => this.features = x);
    }

    add() {
        this.service.create({
            key: this.key,
            description: this.description,
            enabled: this.enabled
        }).subscribe(() => {
            this.key = '';
            this.description = '';
            this.enabled = false;
            this.load();
        });
    }

    remove(id: string) {
        this.service.delete(id).subscribe(() => this.load());
    }
}
