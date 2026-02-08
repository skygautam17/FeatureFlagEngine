import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FeatureFlag } from '../../shared/models/feature-flag.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FeatureApiService {

    private baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    getFeatures() { return this.http.get(`${this.baseUrl}/features`); }
    createFeature(data: any) { return this.http.post(`${this.baseUrl}/features`, data); }
    deleteFeature(id: string) { return this.http.delete(`${this.baseUrl}/features/${id}`); }

    evaluate(
        featureKey: string,
        userId?: string,
        groupId?: string,
        region?: string
    ): Observable<any> {

        let params = new HttpParams()
            .set('featureKey', featureKey);

        if (userId) params = params.set('userId', userId);
        if (groupId) params = params.set('groupId', groupId);
        if (region) params = params.set('region', region);

        return this.http.get(`${this.baseUrl}/evaluate`, { params });
    }

    getOverrides(): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseUrl}/overrides`);
    }

    createOverride(model: any): Observable<any> {
        return this.http.post(`${this.baseUrl}/overrides`, model);
    }

    deleteOverride(id: string): Observable<any> {
        return this.http.delete(`${this.baseUrl}/overrides/${id}`);
    }

    getLogs(): Observable<any[]> {
        return this.http.get<any[]>(`${this.baseUrl}/audit`);
    }
}
