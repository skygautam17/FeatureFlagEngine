import { Component, OnInit } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';

@Component({
    selector: 'app-overrides',
    templateUrl: './overrides.component.html'
})
export class OverridesComponent implements OnInit {

    overrides: any[] = [];

    model: any = {
        featureFlagId: '',
        userId: '',
        groupId: '',
        enabled: true
    };

    loading = false;

    constructor(private api: FeatureApiService) { }

    ngOnInit(): void {
        this.load();
    }

    load(): void {
        this.api.getOverrides().subscribe(res => {
            this.overrides = res;
        });
    }

    create(): void {
        if (!this.model.featureFlagId) return;

        this.loading = true;

        this.api.createOverride(this.model).subscribe({
            next: () => {
                this.model = {
                    featureFlagId: '',
                    userId: '',
                    groupId: '',
                    enabled: true
                };
                this.load();
                this.loading = false;
            },
            error: () => this.loading = false
        });
    }

    delete(id: string): void {
        this.api.deleteOverride(id).subscribe(() => {
            this.load();
        });
    }
}
