import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { IParking } from "../shared/IParking";
import { Parking } from "../shared/Parking";

@Component({
    selector: "parking-list",
  templateUrl : "parkingList.component.html",
    styleUrls: ["ParkingList.Component.css"] //styles aangepast naar styleUrls
})

export class ParkingList implements OnInit {
    PageTitle: string = 'Lijst Parkings';
    backGroundColor: string;
    public parkings: IParking[] = [];
   

    ngOnInit(): void {
        this.data.loadParkings()
            .subscribe(succes => {
                if (succes) {
                    this.parkings = this.data.parkings;
                    this.filteredParkings = this.parkings;
               
                }
            });
    }
   

    _ListFilter : string;
    get listFilter(): string
    {
        return this._ListFilter;
    }
    set listFilter(value: string)
    {
        this._ListFilter = value;
        this.filteredParkings = this.listFilter ? this.perFormFilter(this.listFilter) : this.parkings;
    }

    filteredParkings: IParking[] = this.parkings;

    constructor(private data: DataService) { } 



    perFormFilter(filterBy: string): IParking[]
    {
        filterBy = filterBy.toLocaleLowerCase();
        return this.parkings.filter((parking: IParking) =>
            parking.parkingNaam.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
            parking.landLandNaam.toLocaleLowerCase().indexOf(filterBy) !== -1||
            parking.gemeenteGemeenteNaam.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
            parking.locatieStraat.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
            parking.soortSoortNaam.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }

    //percentage : number = ((parking: Parking) =>
    //    (parking.bezet / parking.totaal) * 100);

    //percentage(): Number{
    //    return 52
        
    //    //return this.parkings.entries((parking: Parking) =>
    //    //    (parking.bezet / parking.totaal) * 100);

    //}

    //getColor(percentage) {
    //    switch (percentage) {
    //        case percentage >= 50:
    //            return 'green';
    //        case percentage <= 51 && percentage >= 75:
    //            return 'yellow';
    //        case percentage <= 76 && percentage >= 90:
    //            return "orange";
    //        case percentage <= 91 && percentage >= 99:
    //            return "Light-red";
    //        case percentage = 100:
    //            return "Dark-Red";
    //        case percentage < 100:
    //            return "Black";


    //    }
    //}

}

