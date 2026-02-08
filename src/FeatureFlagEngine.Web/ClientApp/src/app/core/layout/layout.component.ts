import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  template: `
    <header>
      <h2>Feature Flag Admin</h2>
      <nav>
        <a routerLink="/">Dashboard</a>
        <a routerLink="/features">Features</a>
        <a routerLink="/audit">Audit</a>
      </nav>
      <hr />
    </header>

    <main>
      <router-outlet></router-outlet>
    </main>
  `
})
export class LayoutComponent {}
