import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FeatureListComponent } from './features/feature-list.component';
import { FeatureMaterialTableComponent } from './features/feature-material-table.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuditHistoryComponent } from './audit/audit-history.component';

import { routes } from './app.routes';
import { ApiInterceptor } from './core/interceptors/api.interceptor';

@NgModule({
    declarations: [
        AppComponent,
        FeatureListComponent,
        FeatureMaterialTableComponent,
        DashboardComponent,
        AuditHistoryComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        BrowserAnimationsModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        RouterModule.forRoot(routes)
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
