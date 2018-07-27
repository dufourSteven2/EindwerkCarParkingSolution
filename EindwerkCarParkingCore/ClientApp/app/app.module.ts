import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { CommonModule } from '@angular/common';
//import { HttpModule } from '@angular/http';
import { HttpClientModule } from "@angular/common/http"; //////////////

import { AppComponent } from './app.component';
import { ParkingList } from "./ParkingLijst/parkingList.component";
import { DataService } from './shared/dataService';

@NgModule({
  declarations: [
      AppComponent,
      ParkingList
  ],
  imports: [
      BrowserModule,
      //CommonModule,
      //HttpModule,
      HttpClientModule /////////////////////:
  ],
    providers: [
        DataService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
