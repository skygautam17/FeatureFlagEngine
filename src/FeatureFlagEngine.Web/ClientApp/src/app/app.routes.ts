import { Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('./features/dashboard/dashboard.routes').then(m => m.DASHBOARD_ROUTES)
      },
      {
        path: 'features',
        loadChildren: () => import('./features/features/features.routes').then(m => m.FEATURE_ROUTES)
      },
      {
        path: 'audit',
        loadChildren: () => import('./features/audit/audit.routes').then(m => m.AUDIT_ROUTES)
      }
    ]
  }
];
