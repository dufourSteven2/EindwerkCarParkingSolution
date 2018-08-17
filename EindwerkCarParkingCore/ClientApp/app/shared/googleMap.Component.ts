import { Component, Input } from '@angular/core';
import { GeocodingApiService } from "../Services/GeocodingApiService";

@Component({
    selector: 'googleMap',
    templateUrl: './googleMap.Component.html',
    styleUrls: ['./googleMapComponent.css']
})

export class googleMapComponent {
    lat: number = 5 ;
    lng: number =2;

   // constructor(private geocodingAPIService: GeocodingApiService) {}
    @Input() straatNaam: string;
    @Input() locatienummer: string;
    @Input() gemeente: string;
    @Input() land: string;

   
    adres: string = this.straatNaam;
 
    
       

   

    //updateLatLngFromAddress() {
    //    this.geocodingAPIService
    //        .findFromAddress(this.straatNaam, this.locatienummer, this.gemeente, this.land)
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
}
