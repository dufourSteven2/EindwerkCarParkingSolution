import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class GeocodingApiService {
    API_KEY: string;
    API_URL: string;

    constructor(private http: Http) {
        this.API_KEY = 'AIzaSyCeiTZY7jXETj0MpKuUbKwN_CqeUzv0v'
        this.API_URL = `https://maps.googleapis.com/maps/api/geocode/json?key=${this.API_KEY}&address=`;
    }

    findFromAddress(adres: string): Observable<any> {
        let compositeAddress = [adres];

        if (adres) compositeAddress.push(adres);
        

        let url = `${this.API_URL}${compositeAddress.join(',')}`;

        return this.http.get(url).map(response => <any>response.json());
    }

}