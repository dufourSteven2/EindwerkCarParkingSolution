import { Component, Input, OnInit, OnChanges } from '@angular/core';
import { GeocodingApiService } from "../Services/GeocodingApiService";

@Component({
    selector: 'googleMap',
    templateUrl: './googleMap.Component.html',
    styleUrls: ['./googleMapComponent.css']
})

export class googleMapComponent implements OnChanges {
    lat: number;
    lng: number;

    //constructor(private geocodingAPIService: GeocodingApiService) { }
    @Input() straatNaam: string;
    @Input() locatienummer: string;
    @Input() gemeente: string;
    @Input() land: string;


    adres: string;

    ngOnChanges(): void {
        this.adres = this.straatNaam + " " + this.locatienummer + ","
            + this.gemeente + "," + this.land;
      //  this.updateLatLngFromAddress();
    }






    //updateLatLngFromAddress() {
    //    this.geocodingAPIService
    //        .findFromAddress(this.adres)
    //        .subscribe(response => {
    //            if (response.status == 'OK') {
    //                this.lat = response.results[0].geometry.location.lat;
    //                this.lng = response.results[0].geometry.location.lng;
    //            } else if (response.status == 'ZERO_RESULTS') {
    //                console.log('geocodingAPIService', 'ZERO_RESULTS', response.status);
    //            } else {
    //                console.log('geocodingAPIService', 'Other error', response.status);
    //            }
    //        });
    //}
}
