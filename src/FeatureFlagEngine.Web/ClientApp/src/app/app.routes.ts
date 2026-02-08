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
                path: 'features',
                loadChildren: () =>
                    import('./features/features.routes').then(m => m.FEATURE_ROUTES)
            }
        ]
    }
];
