//import { Injectable } from '@angular/core';
//import { HttpClient } from '@angular/common/http';
//import { Observable } from 'rxjs';
//import { environment } from '../../environments/environment';

//export interface Feature {
//    id: string;
//    key: string;
//    description: string;
//    enabled: boolean;
//}

//@Injectable({ providedIn: 'root' })
//export class FeatureService {
//    private api = `${environment.apiBaseUrl}/features`;

//    constructor(private http: HttpClient) { }

//    getAll(): Observable<Feature[]> {
//        return this.http.get<Feature[]>(this.api);
//    }

//    create(data: Partial<Feature>): Observable<Feature> {
//        return this.http.post<Feature>(this.api, data);
//    }

//    delete(id: string): Observable<void> {
//        return this.http.delete<void>(`${this.api}/${id}`);
//    }
//}
