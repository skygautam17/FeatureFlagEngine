import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';   // <-- required for ngModel

import { DashboardComponent } from './dashboard/dashboard.component';
import { OverridesComponent } from './overrides/overrides.component';
import { AuditHistoryComponent } from './audit/audit-history.component';
import { FeaturesComponent } from './features/features.component';
import { EvaluateComponent } from './evaluate/evaluate.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'overrides', component: OverridesComponent },
  { path: 'evaluates', component: EvaluateComponent },
  { path: 'audithistory', component: AuditHistoryComponent },
  { path: '', component: FeaturesComponent }
];

@NgModule({
  declarations: [
    DashboardComponent,
    OverridesComponent,
    AuditHistoryComponent,
    FeaturesComponent,
    EvaluateComponent   // <-- missing earlier
  ],
  imports: [
    CommonModule,
    FormsModule,         // <-- add this
    RouterModule.forChild(routes)
  ]
})
export class FeaturesModule {}
