import { Component } from "@angular/core";
import { templateJitUrl } from "@angular/compiler";

@Component({
    selector: "parking-list",
  //  template: "<div>test parkinglijst</div>",
   templateUrl : "parkingList.component.html",
    styles: []
})
export class ParkingList {
    public parkings = [
        {
            name : "benny",
            plaats : "brugge"
        },
        {
            name: "Steven",
            plaats: "brugge"
        },
        {
            name: "William",
            plaats: "brugge"
        }
    ];
}