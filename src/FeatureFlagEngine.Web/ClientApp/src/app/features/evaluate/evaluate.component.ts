import { Component } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';

@Component({
  selector: 'app-evaluate',
  templateUrl: './evaluate.component.html'
})
export class EvaluateComponent {

  featureKey: string = '';
  result: any = null;

  constructor(private api: FeatureApiService) {}

  run(): void {
    if (!this.featureKey) return;

    this.api.evaluate(this.featureKey).subscribe({
      next: (res) => this.result = res,
      error: (err) => {
        console.error(err);
        this.result = { error: 'Failed to evaluate feature' };
      }
    });
  }
}
