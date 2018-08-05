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
var Gemeentes = /** @class */ (function () {
    function Gemeentes(data) {
        this.data = data;
        this.PageTitle = 'Lijst steden';
        this.gemeentes = [];
    }
    Gemeentes.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadGemeentes()
            .subscribe(function (succes) {
            if (succes) {
                _this.gemeentes = _this.data.gemeentes;
            }
        });
    };
    Gemeentes = __decorate([
        core_1.Component({
            selector: "Gemeentes",
            templateUrl: "Gemeente.component.html",
        }),
        __metadata("design:paramtypes", [dataService_1.DataService])
    ], Gemeentes);
    return Gemeentes;
}());
exports.Gemeentes = Gemeentes;
//# sourceMappingURL=Gemeente.Component.js.map