import { Component, OnInit } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html'
})
export class FeaturesComponent implements OnInit {
  features:any[]=[];
  newFeature:any={ key:'', enabled:false };

    constructor(private api: FeatureApiService){}

  ngOnInit(){
    debugger;
     this.load(); 
    }

  load(){
    this.api.getFeatures().subscribe((res:any)=>this.features=res);
  }

  create(){
    this.api.createFeature(this.newFeature).subscribe(()=>{
      this.newFeature={ key:'', enabled:false };
      this.load();
    });
  }

  delete(id:string){
    this.api.deleteFeature(id).subscribe(()=>this.load());
  }

  edit(feature: any) {
  feature.isEditing = true;
}

cancelEdit(feature: any) {
  feature.isEditing = false;
  this.load();   // reload original values
}

update(feature: any) {
  this.api.updateFeature(feature).subscribe(() => {
    feature.isEditing = false;
    this.load();
  });
}
}