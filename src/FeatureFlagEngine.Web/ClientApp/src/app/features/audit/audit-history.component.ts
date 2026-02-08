
import { Component } from '@angular/core';
import { FeatureApiService } from '../services/feature-api.service';
@Component({
 selector:'app-audit-history',
 templateUrl: './audit-history.component.html',
})
export class AuditHistoryComponent {

    logs: any[] = [];
  loading = false;

  constructor(private api: FeatureApiService) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.loading = true;

    this.api.getLogs().subscribe({
      next: res => {
        this.logs = res;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }
}


