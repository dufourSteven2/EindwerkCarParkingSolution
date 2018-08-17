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

export class Gemeentes implements OnInit
{
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
    //_ListFilter: string;
    //get listFilter(): string {
    //    return this._ListFilter;
    //}
    //set listFilter(value: string) {
    //    this._ListFilter = value;
    //    this.filteredGemeentes = this.listFilter ? this.perFormFilter(this.listFilter) : this.parkings;
    //}
    //filteredGemeentes: IGemeente[] = this.gemeentes;

    //perFormFilter(filterBy: string): IGemeente[] {
    //    filterBy = filterBy.toLocaleLowerCase();
    //    return this.gemeentes.filter((gemeente: IGemeente) =>
    //        gemeente.Land.toLocaleLowerCase().indexOf(filterBy) !== -1 ;

    //}

}
