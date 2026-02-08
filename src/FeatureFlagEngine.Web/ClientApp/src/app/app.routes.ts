import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';
import { authGuard } from './core/guards/auth.guard';
import { NgModule } from '@angular/core';

export const routes: Routes = [
    {
        path: '',
        component: LayoutComponent,
        /*canActivate: [authGuard],*/
        children: [
            {
                path: 'features',
                loadChildren: () =>
                    import('./features/features.module').then(m => m.FeaturesModule)
            }
        ]
    },
    { path: '', redirectTo: 'features/dashboard', pathMatch: 'full' }

];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}