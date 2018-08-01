import { DataService } from "../shared/dataService";
import { Component } from "@angular/core";


@Component({
    selector: "Locatie",
    templateUrl: "locatie.component.html",
    styleUrls:[]
})

export class Locatie {
    constructor(private data: DataService) {

    }
}