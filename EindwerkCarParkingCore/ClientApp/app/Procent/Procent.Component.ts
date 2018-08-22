import { Component, OnChanges, Input } from "@angular/core";

@Component({
    selector: 'Procent',
    templateUrl: './Procent.Component.html',
    styleUrls: ['./Procent.Component.css']

})

export class ProcentComponent implements OnChanges {
    @Input() Totaal : number;
    @Input() bezet : number;

    procent: number;

    ngOnChanges(): void {
        this.procent = this.Totaal;
    }
}