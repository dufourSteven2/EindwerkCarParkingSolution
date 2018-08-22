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
var dataService_1 = require("../shared/dataService");
var ParkingList = /** @class */ (function () {
    function ParkingList(data) {
        this.data = data;
        this.PageTitle = 'Lijst Parkings';
        this.parkings = [];
        // @Input() totaal: number;
        //@Input() bezet: number;
        this.procent = 5;
        this.filteredParkings = this.parkings;
    }
    ParkingList.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadParkings()
            .subscribe(function (succes) {
            if (succes) {
                _this.parkings = _this.data.parkings;
                _this.filteredParkings = _this.parkings;
            }
        });
        //this.procent = (this.bezet / this.totaal) * 100;
    };
    Object.defineProperty(ParkingList.prototype, "listFilter", {
        get: function () {
            return this._ListFilter;
        },
        set: function (value) {
            this._ListFilter = value;
            this.filteredParkings = this.listFilter ? this.perFormFilter(this.listFilter) : this.parkings;
        },
        enumerable: true,
        configurable: true
    });
    ParkingList.prototype.perFormFilter = function (filterBy) {
        filterBy = filterBy.toLocaleLowerCase();
        return this.parkings.filter(function (parking) {
            return parking.parkingNaam.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
                parking.landLandNaam.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
                parking.gemeenteGemeenteNaam.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
                parking.locatieStraat.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
                parking.soortSoortNaam.toLocaleLowerCase().indexOf(filterBy) !== -1;
        });
    };
    ParkingList = __decorate([
        core_1.Component({
            selector: "parking-list",
            templateUrl: "parkingList.component.html",
            styleUrls: ["ParkingList.Component.css"] //styles aangepast naar styleUrls
        }),
        __metadata("design:paramtypes", [dataService_1.DataService])
    ], ParkingList);
    return ParkingList;
}());
exports.ParkingList = ParkingList;
//# sourceMappingURL=ParkingList.component.js.map