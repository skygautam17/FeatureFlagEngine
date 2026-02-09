import { Component, OnInit } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html'
})
export class FeaturesComponent implements OnInit {

  features: any[] = [];

  newFeature: any = {
    key: '',
    description: '',
    enabled: false
  };

  constructor(private api: FeatureApiService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.api.getFeatures().subscribe((res: any) => this.features = res);
  }

  create(form: NgForm) {

    if (form.invalid) return;

    this.api.createFeature(this.newFeature).subscribe(() => {

      // Reset model
      this.newFeature = {
        key: '',
        description: '',
        enabled: false
      };

      // Clear validators + form state
      form.resetForm(this.newFeature);

      this.load();
    });
  }

  delete(id: string) {
    this.api.deleteFeature(id).subscribe(() => this.load());
  }

  edit(feature: any) {
  feature.original = { ...feature };
  feature.isEditing = true;
}

cancelEdit(feature: any, form: NgForm) {
  Object.assign(feature, feature.original);
  feature.isEditing = false;
  form.resetForm(feature);
  this.load();
}

  update(feature: any, form: NgForm) {

  if (form.invalid) {
    form.control.markAllAsTouched();
    return;
  }

  this.api.updateFeature(feature).subscribe(() => {
    feature.isEditing = false;

    // reset validation state
    form.resetForm(feature);

    this.load();
  });
}
}
