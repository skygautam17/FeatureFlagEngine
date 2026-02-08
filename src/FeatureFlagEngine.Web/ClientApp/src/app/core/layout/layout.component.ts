import { Component } from '@angular/core';

@Component({
  selector: 'app-layout',
  template: `
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">

    <a class="navbar-brand" href="#">Feature Flag Admin</a>

    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarNav">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarNav">
      <ul class="navbar-nav ms-auto">

        <li class="nav-item">
          <a class="nav-link" routerLink="/features/dashboard" routerLinkActive="active">
            Dashboard
          </a>
        </li>

        <li class="nav-item">
          <a class="nav-link" routerLink="/features" routerLinkActive="active">
            Features
          </a>
        </li>

        <li class="nav-item">
          <a class="nav-link" routerLink="/features/overrides" routerLinkActive="active">
            Overrides
          </a>
        </li>

        <li class="nav-item">
          <a class="nav-link" routerLink="/features/evaluates" routerLinkActive="active">
            Evaluate
          </a>
        </li>

        <li class="nav-item">
          <a class="nav-link" routerLink="/features/audithistory" routerLinkActive="active">
            Audit
          </a>
        </li>

      </ul>
    </div>

  </div>
</nav>

<div class="container mt-4">
  <router-outlet></router-outlet>
</div>

  `
})
export class LayoutComponent {}
