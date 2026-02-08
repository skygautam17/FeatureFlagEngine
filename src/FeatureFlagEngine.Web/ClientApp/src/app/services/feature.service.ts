
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn:'root'})
export class FeatureService {
  private api='/api/features';
  constructor(private http:HttpClient){}
  getAll(){return this.http.get(this.api);}
  create(data:any){return this.http.post(this.api,data);}
  delete(id:string){return this.http.delete(`${this.api}/${id}`);}
}
