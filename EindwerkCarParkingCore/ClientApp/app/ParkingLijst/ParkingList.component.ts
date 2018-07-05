import { Component, OnInit } from "@angular/core";
import { templateJitUrl } from "@angular/compiler";
import { DataService } from "../shared/dataService";

@Component({
    selector: "parking-list",
  //  template: "<div>test parkinglijst</div>",
   templateUrl : "parkingList.component.html",
    styles: []
})
export class ParkingList implements OnInit {
    constructor(private data: DataService) {
        
    }
    public parkings = [];

    ngOnInit(): void {
        this.data.loadParkings()
            .subscribe(succes => {
                if (succes) {
                    this.parkings = this.data.parkings;
                }
            });
    }
}