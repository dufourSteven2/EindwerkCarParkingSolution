import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { IParking } from "../shared/IParking";
import { ISoort } from "../shared/ISoort";

@Component({
    selector: "Soorten",
    templateUrl: "Soorten.component.html",
    // styleUrls: ["Landen.Component.css"] //styles aangepast naar styleUrls
})

export class Soorten implements OnInit {
    PageTitle: string = 'Lijst Soorten';

    public Soorten: ISoort[] = [];
    constructor(private data: DataService) { }

    ngOnInit(): void {
        this.data.loadSoorten()
            .subscribe(succes => {
                if (succes) {
                    this.Soorten = this.data.soorten;
                }
            })
    }

}
