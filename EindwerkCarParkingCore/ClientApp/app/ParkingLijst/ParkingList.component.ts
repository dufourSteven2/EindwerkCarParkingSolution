import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Parking } from "../shared/Parking";
@Component({
    selector: "parking-list",
    // template: "<div>test parkinglijst</div>",
  templateUrl : "../ParkingLijst/parkingList.component.html",
    styleUrls: [] //styles aangepast naar styleUrls
})

export class ParkingList implements OnInit {
    constructor(private data: DataService) {
        
    }
    public parkings : Parking[] =[];

    ngOnInit(): void {
        this.data.loadParkings()
            .subscribe(succes => {
                if (succes) {
                    this.parkings = this.data.parkings;
                }
            });
    }
}

