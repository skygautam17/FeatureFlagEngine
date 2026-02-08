import { Component, OnInit } from '@angular/core';
import { FeatureApiService } from '../../features/services/feature-api.service';

@Component({
  selector: 'app-overrides',
  templateUrl: './overrides.component.html'
})
export class OverridesComponent implements OnInit {
  overrides:any[]=[];
  model:any={ featureFlagId:'', userId:'', groupId:'', enabled:true };

    constructor(private api: FeatureApiService){}

  ngOnInit(){ this.load(); }

  load(){ this.api.getOverrides().subscribe((res:any)=>this.overrides=res); }

  create(){
    this.api.createOverride(this.model).subscribe(()=>{
      this.model={ featureFlagId:'', userId:'', groupId:'', enabled:true };
      this.load();
    });
  }
}
