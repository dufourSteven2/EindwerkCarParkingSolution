import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import 'rxjs/add/operator/map';
import { Parking } from "./Parking";

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    public parkings : Parking[]/* type safety typing*/ = [] /*signing*/;

    loadParkings():Observable<boolean> {
        return this.http.get("/api/parkings") // hier de weg naar de apiom parkings op te halen
            .map((data: any[]) => {
                this.parkings = data;
                return true;
            });
    }
}