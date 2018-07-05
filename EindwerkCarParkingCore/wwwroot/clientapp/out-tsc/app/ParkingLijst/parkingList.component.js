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
        this.parkings = [];
    }
    ParkingList.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadParkings()
            .subscribe(function (succes) {
            if (succes) {
                _this.parkings = _this.data.parkings;
            }
        });
    };
    ParkingList = __decorate([
        core_1.Component({
            selector: "parking-list",
            // template: "<div>test parkinglijst</div>",
            templateUrl: "parkingList.component.html",
            styles: []
        }),
        __metadata("design:paramtypes", [dataService_1.DataService])
    ], ParkingList);
    return ParkingList;
}());
exports.ParkingList = ParkingList;
//# sourceMappingURL=ParkingList.component.js.map