"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var googleMapComponent = /** @class */ (function () {
    function googleMapComponent() {
        this.lat = 5;
        this.lng = 2;
        //updateLatLngFromAddress() {
        //    this.geocodingAPIService
        //        .findFromAddress(this.straatNaam, this.locatienummer, this.gemeente, this.land)
        //        .subscribe(response => {
        //            if (response.status == 'OK') {
        //                this.lat = response.results[0].geometry.location.lat;
        //                this.lng = response.results[0].geometry.location.lng;
        //            } else if (response.status == 'ZERO_RESULTS') {
        //                console.log('geocodingAPIService', 'ZERO_RESULTS', response.status);
        //            } else {
        //                console.log('geocodingAPIService', 'Other error', response.status);
        //            }
        //        });
    }
    googleMapComponent.prototype.ngOnChanges = function () {
        this.adres = this.straatNaam + " " + this.locatienummer + ","
            + this.gemeente + "," + this.land;
    };
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], googleMapComponent.prototype, "straatNaam", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], googleMapComponent.prototype, "locatienummer", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], googleMapComponent.prototype, "gemeente", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", String)
    ], googleMapComponent.prototype, "land", void 0);
    googleMapComponent = __decorate([
        core_1.Component({
            selector: 'googleMap',
            templateUrl: './googleMap.Component.html',
            styleUrls: ['./googleMapComponent.css']
        })
    ], googleMapComponent);
    return googleMapComponent;
}());
exports.googleMapComponent = googleMapComponent;
//# sourceMappingURL=googleMap.Component.js.map