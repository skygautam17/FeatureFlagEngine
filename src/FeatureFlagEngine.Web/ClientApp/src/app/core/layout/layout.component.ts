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
        <a routerLink="/features/dashboard">Dashboard</a>
        <a routerLink="/features/overrides">Overrides</a>
        <a routerLink="/features/audithistory">Audit</a>
      </nav>
      <hr />
    </header>

    <main>
      <router-outlet></router-outlet>
    </main>
  `
})
export class LayoutComponent {}
