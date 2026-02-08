import { Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  template: `
    <header>
      <h2>Feature Flag Admin</h2>
      <nav>
        <a routerLink="/features/dashboard">Dashboard</a>
        <a routerLink="/features">Features</a>
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
