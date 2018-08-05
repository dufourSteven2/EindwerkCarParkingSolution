import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http"; //////////////
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { ParkingList } from "./ParkingLijst/ParkingList.component";
import { DataService } from './shared/dataService';
import { Landen } from './Landen/Landen.Component';
import { Gemeentes } from './Gemeentes/Gemeente.Component';
import { Soorten } from './Soorten/Soorten.Component';

@NgModule({
  declarations: [
      AppComponent,
      ParkingList,
      Landen,
      Gemeentes,
      Soorten
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule /////////////////////:
  ],
    providers: [
        DataService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
