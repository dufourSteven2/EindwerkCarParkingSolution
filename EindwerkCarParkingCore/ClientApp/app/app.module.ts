import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http"; //////////////
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { ParkingList } from "./ParkingLijst/ParkingList.component";
import { DataService } from './shared/dataService';

@NgModule({
  declarations: [
      AppComponent,
      ParkingList
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
