import { Component, OnInit } from "@angular/core";
import { DataService } from "../shared/dataService";
import { IParking } from "../shared/IParking";
import { ILand } from "../shared/ILand";

@Component({
    selector: "Landen",
    templateUrl: "Landen.component.html",
   // styleUrls: ["Landen.Component.css"] //styles aangepast naar styleUrls
})

export class Landen implements OnInit {
    PageTitle: string = 'Lijst Parkingen';

    public Landen: ILand[] = [];
    constructor(private data: DataService) { }

    ngOnInit(): void {
        this.data.loadLanden()
            .subscribe(succes => {
                if (succes) {
                    this.Landen = this.data.landen;
                }
            })
    }

}
