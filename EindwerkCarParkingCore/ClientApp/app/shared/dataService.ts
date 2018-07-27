﻿import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
//import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {


    constructor(private http: HttpClient) { }

    public parkings = [];

    loadParkings() {
        return this.http.get("/api/parkings") 
            .map((data: any[]) => {
                this.parkings = data;
                return true;
            
            });
    }
}