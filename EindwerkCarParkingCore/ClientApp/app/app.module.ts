import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ParkingList } from "./ParkingLijst/ParkingList.component";

@NgModule({
  declarations: [
      AppComponent,
      ParkingList
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
