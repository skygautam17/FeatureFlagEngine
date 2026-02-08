import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { AppComponent } from './app.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { AuditHistoryComponent } from './features/audit/audit-history.component';

import { AppRoutingModule } from './app.routes';
import { ApiInterceptor } from './core/interceptors/api.interceptor';
import { EvaluateComponent } from './features/evaluate/evaluate.component';
import { OverridesComponent } from './features/overrides/overrides.component';
import { FeaturesComponent } from './features/features/features.component';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from "./core/layout/layout.component";

@NgModule({
    declarations: [
        AppComponent,
        LayoutComponent,
    ],
    imports: [
    BrowserModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    AppRoutingModule,
],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ApiInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
