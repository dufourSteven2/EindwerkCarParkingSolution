import { Component } from "@angular/core";
import { templateJitUrl } from "@angular/compiler";
import { DataService } from "../shared/dataService";

@Component({
    selector: "parking-list",
  //  template: "<div>test parkinglijst</div>",
   templateUrl : "parkingList.component.html",
    styles: []
})
export class ParkingList {
    constructor(private data: DataService) {
        this.parkings = data.parkings;
    }
    public parkings = [    ];
}