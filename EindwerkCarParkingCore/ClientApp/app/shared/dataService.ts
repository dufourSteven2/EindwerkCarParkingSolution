import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import 'rxjs/add/operator/map';
import { IParking } from "./IParking";
import { ILand } from "./ILand";
import { Parking } from "./Parking";
import { IGemeente } from './IGemeente';
import { ISoort } from './ISoort';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) { }

    public parkings: IParking[] =[]; /*type safety */
    public landen: ILand[] =[];
    public gemeentes: IGemeente[] = [];
    public soorten: ISoort[] = [];

    loadParkings(): Observable<boolean> {
        return this.http.get("/api/parkings") // hier de weg naar de apiom parkings op te halen
            .map((data: any[]) => {
                this.parkings = data;
                return true;
            });
    };

    loadLanden(): Observable<boolean> {
        return this.http.get("/api/landen") // hier de weg naar de api om Landen op te halen
            .map((data: any[]) => {
                this.landen = data;
                return true;
            });
    };

    loadGemeentes(): Observable<boolean> {
        return this.http.get("/api/gemeentes") // hier de weg naar de api om Landen op te halen
            .map((data: any[]) => {
                this.gemeentes = data;
                return true;
            });
    };

    loadSoorten(): Observable<boolean> {
        return this.http.get("/api/soorts") // hier de weg naar de api om Landen op te halen
            .map((data: any[]) => {
                this.soorten = data;
                return true;
            });
    };
}