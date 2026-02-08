import { Component } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';

@Component({
    selector: 'app-evaluate',
    templateUrl: './evaluate.component.html'
})
export class EvaluateComponent {

    featureKey: string = '';
    userId: string = '';
    groupId: string = '';
    region: string = '';

    result: any = null;
    loading = false;

    constructor(private api: FeatureApiService) { }

    run(): void {
        if (!this.featureKey) return;

        this.loading = true;
        this.result = null;

        this.api.evaluate(
            this.featureKey,
            this.userId || undefined,
            this.groupId || undefined,
            this.region || undefined
        ).subscribe({
            next: (res) => {
                this.result = res;
                this.loading = false;
            },
            error: (err) => {
                console.error(err);
                this.result = { error: 'Failed to evaluate feature' };
                this.loading = false;
            }
        });
    }
}
