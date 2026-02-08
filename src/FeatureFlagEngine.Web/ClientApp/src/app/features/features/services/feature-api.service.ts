import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FeatureFlag } from '../../../shared/models/feature-flag.model';

@Injectable({
  providedIn: 'root'
})
export class FeatureApiService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<FeatureFlag[]> {
    return this.http.get<FeatureFlag[]>('features');
  }
}
