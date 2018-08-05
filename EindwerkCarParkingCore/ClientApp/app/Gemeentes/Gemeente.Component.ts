import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { IParking } from "../shared/IParking";
import { ILand } from "../shared/ILand";
import {IGemeente} from "../shared/IGemeente"

@Component({
    selector: "Gemeentes",
    templateUrl: "Gemeente.component.html",
    // styleUrls: ["Landen.Component.css"] //styles aangepast naar styleUrls
})

export class Gemeentes implements OnInit {
    PageTitle: string = 'Lijst steden';

    public gemeentes: IGemeente[] = [];
    constructor(private data: DataService) { }

    ngOnInit(): void {
        this.data.loadGemeentes()
            .subscribe(succes => {
                if (succes) {
                    this.gemeentes = this.data.gemeentes;
                }
            })
    }

}
