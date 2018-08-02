import { IParking } from "./IParking";
import * as _ from "lodash";

export class Parking implements IParking {
    constructor(
        public id: number,
        public parkingNaam: string,
        public landLandNaam: string,
        public gemeenteGemeenteNaam: string,
        public locatieStraat: string,
        public locatieNummer: string,
        public soortSoortNaam: string,
        public totaal: number,
        public bezet: number) { }

    get calculateProcentBezetParking(): number {
        return _.sum(this.totaal - this.bezet);
    }

}