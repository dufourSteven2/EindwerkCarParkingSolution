"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var _ = require("lodash");
var Parking = /** @class */ (function () {
    function Parking(id, parkingNaam, landLandNaam, gemeenteGemeenteNaam, locatieStraat, locatieNummer, soortSoortNaam, totaal, bezet) {
        this.id = id;
        this.parkingNaam = parkingNaam;
        this.landLandNaam = landLandNaam;
        this.gemeenteGemeenteNaam = gemeenteGemeenteNaam;
        this.locatieStraat = locatieStraat;
        this.locatieNummer = locatieNummer;
        this.soortSoortNaam = soortSoortNaam;
        this.totaal = totaal;
        this.bezet = bezet;
    }
    Object.defineProperty(Parking.prototype, "calculateProcentBezetParking", {
        get: function () {
            return _.sum(this.totaal - this.bezet);
        },
        enumerable: true,
        configurable: true
    });
    return Parking;
}());
exports.Parking = Parking;
//# sourceMappingURL=Parking.js.map