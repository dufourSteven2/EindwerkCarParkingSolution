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

    findFromAddress(straatNaam: string, locatienummer: string, gemeente: string, land:string): Observable<any> {
        let compositeAddress = [straatNaam, locatienummer, gemeente, land];

        if (straatNaam) compositeAddress.push(straatNaam);
        if (locatienummer) compositeAddress.push(locatienummer);
        if (gemeente) compositeAddress.push(gemeente);
        if (land) compositeAddress.push(land);

        let url = `${this.API_URL}${compositeAddress.join(',')}`;

        return this.http.get(url).map(response => <any>response.json());
    }

}