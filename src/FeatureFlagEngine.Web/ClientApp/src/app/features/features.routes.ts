import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EvaluateComponent } from './evaluate/evaluate.component';
import { OverridesComponent } from './overrides/overrides.component';
import { AuditHistoryComponent } from './audit/audit-history.component';
import { FeaturesComponent } from './features/features.component';

export const FEATURE_ROUTES: Routes = [
    { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

    { path: 'dashboard', component: DashboardComponent },
    { path: '/', component: FeaturesComponent },
    { path: 'evaluates', component: EvaluateComponent },
    { path: 'audithistory', component: AuditHistoryComponent },
    { path: 'overrides', component: OverridesComponent }
];
