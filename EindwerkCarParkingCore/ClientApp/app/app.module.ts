import { ProcentComponent } from './Procent/Procent.Component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http"; //////////////
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { ParkingList } from "./ParkingLijst/ParkingList.component";
import { DataService } from './shared/dataService';
import { googleMapComponent } from './shared/googleMap.Component';
import { Landen } from './Landen/Landen.Component';
import { Gemeentes } from './Gemeentes/Gemeente.Component';
import { Soorten } from './Soorten/Soorten.Component';
import { AgmCoreModule } from '@agm/core';
import { GeocodingApiService } from './Services/GeocodingApiService';
@NgModule({
  declarations: [
      AppComponent,
      ParkingList,
      Landen,
      Gemeentes,
      Soorten,
      googleMapComponent,
      ProcentComponent
      
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule, /////////////////////:
     AgmCoreModule.forRoot({
         apiKey: 'AIzaSyCeiTZY7jXETj0MpKuUbKwN_CqeUzv0v-M'
      }),

  ],
    providers: [
        DataService, 
        GeocodingApiService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
