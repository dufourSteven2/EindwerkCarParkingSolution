(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./ClientApp/$$_lazy_route_resource lazy recursive":
/*!****************************************************************!*\
  !*** ./ClientApp/$$_lazy_route_resource lazy namespace object ***!
  \****************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error('Cannot find module "' + req + '".');
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./ClientApp/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./ClientApp/app/Gemeentes/Gemeente.Component.ts":
/*!*******************************************************!*\
  !*** ./ClientApp/app/Gemeentes/Gemeente.Component.ts ***!
  \*******************************************************/
/*! exports provided: Gemeentes */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Gemeentes", function() { return Gemeentes; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_dataService__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/dataService */ "./ClientApp/app/shared/dataService.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "Gemeentes",
            template: __webpack_require__(/*! ./Gemeente.component.html */ "./ClientApp/app/Gemeentes/Gemeente.component.html"),
        }),
        __metadata("design:paramtypes", [_shared_dataService__WEBPACK_IMPORTED_MODULE_1__["DataService"]])
    ], Gemeentes);
    return Gemeentes;
}());



/***/ }),

/***/ "./ClientApp/app/Gemeentes/Gemeente.component.html":
/*!*********************************************************!*\
  !*** ./ClientApp/app/Gemeentes/Gemeente.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div>\r\n\t<select>\r\n\t\t<option *ngFor=\"let G of gemeentes\" value=\"{{G.gemeenteNaam}}\">{{G.gemeenteNaam}}</option>\r\n\t</select>\r\n</div>"

/***/ }),

/***/ "./ClientApp/app/Landen/Landen.Component.ts":
/*!**************************************************!*\
  !*** ./ClientApp/app/Landen/Landen.Component.ts ***!
  \**************************************************/
/*! exports provided: Landen */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Landen", function() { return Landen; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_dataService__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/dataService */ "./ClientApp/app/shared/dataService.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var Landen = /** @class */ (function () {
    function Landen(data) {
        this.data = data;
        this.PageTitle = 'Lijst Parkingen';
        this.Landen = [];
    }
    Landen.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadLanden()
            .subscribe(function (succes) {
            if (succes) {
                _this.Landen = _this.data.landen;
            }
        });
    };
    Landen = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "Landen",
            template: __webpack_require__(/*! ./Landen.component.html */ "./ClientApp/app/Landen/Landen.component.html"),
        }),
        __metadata("design:paramtypes", [_shared_dataService__WEBPACK_IMPORTED_MODULE_1__["DataService"]])
    ], Landen);
    return Landen;
}());



/***/ }),

/***/ "./ClientApp/app/Landen/Landen.component.html":
/*!****************************************************!*\
  !*** ./ClientApp/app/Landen/Landen.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <select >\r\n        <option *ngFor=\"let L of Landen\" value=\"{{L.landNaam}}\">{{L.landNaam}}</option>\r\n    </select>\r\n</div>\r\n"

/***/ }),

/***/ "./ClientApp/app/ParkingLijst/ParkingList.Component.css":
/*!**************************************************************!*\
  !*** ./ClientApp/app/ParkingLijst/ParkingList.Component.css ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div.parking.header{\r\n    font-size: large;\r\n}\r\n\r\ndiv.parking{\r\n    margin-top : 10px;\r\n}\r\n\r\n.table{\r\n    margin-top: 10px;\r\n}\r\n\r\n.tableparkinginfo{\r\n    padding : 1px;\r\n    font-size: 16px;\r\n}\r\n"

/***/ }),

/***/ "./ClientApp/app/ParkingLijst/ParkingList.component.ts":
/*!*************************************************************!*\
  !*** ./ClientApp/app/ParkingLijst/ParkingList.component.ts ***!
  \*************************************************************/
/*! exports provided: ParkingList */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParkingList", function() { return ParkingList; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_dataService__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/dataService */ "./ClientApp/app/shared/dataService.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var ParkingList = /** @class */ (function () {
    function ParkingList(data) {
        this.data = data;
        this.PageTitle = 'Lijst Parkings';
        this.parkings = [];
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
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "parking-list",
            template: __webpack_require__(/*! ./parkingList.component.html */ "./ClientApp/app/ParkingLijst/parkingList.component.html"),
            styles: [__webpack_require__(/*! ./ParkingList.Component.css */ "./ClientApp/app/ParkingLijst/ParkingList.Component.css")]
        }),
        __metadata("design:paramtypes", [_shared_dataService__WEBPACK_IMPORTED_MODULE_1__["DataService"]])
    ], ParkingList);
    return ParkingList;
}());



/***/ }),

/***/ "./ClientApp/app/ParkingLijst/parkingList.component.html":
/*!***************************************************************!*\
  !*** ./ClientApp/app/ParkingLijst/parkingList.component.html ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"parking\">\r\n    <div class=\"parking.header\">\r\n        {{PageTitle}}\r\n    </div>\r\n    <div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-2\">Zoeken: </div>\r\n            <div class=\"col-md-4\">\r\n                <input type=\"text\" [(ngModel)]=\"listFilter\" />\r\n            </div>\r\n        </div>   \r\n        <div class=\"row\">\r\n            <div class=\"col-md-6\">\r\n                <h4>Filterd door: {{listFilter}}</h4>\r\n            </div>\r\n        </div>\r\n        <div class=\"table-responsive\">\r\n            <table class=\"table\" *ngIf='parkings && parkings.length > 0'>\r\n                <thead>\r\n                    <tr>\r\n                        <th>Parkingnaam: </th>\r\n                        <th> Land: </th>\r\n                        <th> Gemeente: </th>\r\n                        <th>Straat: </th>\r\n                        <th>Nummer: </th>\r\n                        <th>Soort: </th>\r\n                        <th>Bezet: </th>\r\n                        <th> Aantal: </th>\r\n                        <th>Vrije plaatsen: </th>\r\n                        <th>Percentage bezet:</th>\r\n                       \r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr class=\"tableparkinginfo\" *ngFor=\"let p of filteredParkings\">\r\n                        <td>{{p.parkingNaam}} </td>\r\n                        <td>{{p.landLandNaam}}</td>\r\n                        <td>{{p.gemeenteGemeenteNaam}}</td>\r\n                        <td>{{p.locatieStraat}}</td>\r\n                        <td>{{p.locatieNummer}}</td>\r\n                        <td>{{p.soortSoortNaam}}</td>\r\n                        <td ng-model=\"bezet\">{{p.bezet}}</td>\r\n                        <td ng-model=\"Totaal\">{{p.totaal}}</td>\r\n                        <td>{{ p.totaal - p.bezet }}</td>\r\n                        <td>{{(p.bezet / p.totaal)*100}} %</td>\r\n                        \r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n"

/***/ }),

/***/ "./ClientApp/app/Soorten/Soorten.Component.ts":
/*!****************************************************!*\
  !*** ./ClientApp/app/Soorten/Soorten.Component.ts ***!
  \****************************************************/
/*! exports provided: Soorten */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Soorten", function() { return Soorten; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shared_dataService__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../shared/dataService */ "./ClientApp/app/shared/dataService.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};


var Soorten = /** @class */ (function () {
    function Soorten(data) {
        this.data = data;
        this.PageTitle = 'Lijst Soorten';
        this.Soorten = [];
    }
    Soorten.prototype.ngOnInit = function () {
        var _this = this;
        this.data.loadSoorten()
            .subscribe(function (succes) {
            if (succes) {
                _this.Soorten = _this.data.soorten;
            }
        });
    };
    Soorten = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: "Soorten",
            template: __webpack_require__(/*! ./Soorten.component.html */ "./ClientApp/app/Soorten/Soorten.component.html"),
        }),
        __metadata("design:paramtypes", [_shared_dataService__WEBPACK_IMPORTED_MODULE_1__["DataService"]])
    ], Soorten);
    return Soorten;
}());



/***/ }),

/***/ "./ClientApp/app/Soorten/Soorten.component.html":
/*!******************************************************!*\
  !*** ./ClientApp/app/Soorten/Soorten.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div>\r\n    <select>\r\n        <option *ngFor=\"let S of Soorten\" value=\"{{S.soortNaam}}\">{{S.soortNaam}}</option>\r\n    </select>\r\n</div>"

/***/ }),

/***/ "./ClientApp/app/app.component.html":
/*!******************************************!*\
  !*** ./ClientApp/app/app.component.html ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<!--The content below is only a placeholder and can be replaced.-->\r\n\r\n<div>\r\n    <Landen></Landen>\r\n    <Gemeentes></Gemeentes>\r\n    <Soorten></Soorten>\r\n</div>\r\n\r\n\r\n<div class=\"col-md-10\" >\r\n<parking-list></parking-list>\r\n</div>"

/***/ }),

/***/ "./ClientApp/app/app.component.ts":
/*!****************************************!*\
  !*** ./ClientApp/app/app.component.ts ***!
  \****************************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var AppComponent = /** @class */ (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'the-parkings',
            template: __webpack_require__(/*! ./app.component.html */ "./ClientApp/app/app.component.html"),
            styles: []
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./ClientApp/app/app.module.ts":
/*!*************************************!*\
  !*** ./ClientApp/app/app.module.ts ***!
  \*************************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./ClientApp/app/app.component.ts");
/* harmony import */ var _ParkingLijst_ParkingList_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./ParkingLijst/ParkingList.component */ "./ClientApp/app/ParkingLijst/ParkingList.component.ts");
/* harmony import */ var _shared_dataService__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./shared/dataService */ "./ClientApp/app/shared/dataService.ts");
/* harmony import */ var _Landen_Landen_Component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./Landen/Landen.Component */ "./ClientApp/app/Landen/Landen.Component.ts");
/* harmony import */ var _Gemeentes_Gemeente_Component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./Gemeentes/Gemeente.Component */ "./ClientApp/app/Gemeentes/Gemeente.Component.ts");
/* harmony import */ var _Soorten_Soorten_Component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./Soorten/Soorten.Component */ "./ClientApp/app/Soorten/Soorten.Component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


 //////////////







var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"],
                _ParkingLijst_ParkingList_component__WEBPACK_IMPORTED_MODULE_5__["ParkingList"],
                _Landen_Landen_Component__WEBPACK_IMPORTED_MODULE_7__["Landen"],
                _Gemeentes_Gemeente_Component__WEBPACK_IMPORTED_MODULE_8__["Gemeentes"],
                _Soorten_Soorten_Component__WEBPACK_IMPORTED_MODULE_9__["Soorten"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClientModule"] /////////////////////:
            ],
            providers: [
                _shared_dataService__WEBPACK_IMPORTED_MODULE_6__["DataService"]
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./ClientApp/app/shared/dataService.ts":
/*!*********************************************!*\
  !*** ./ClientApp/app/shared/dataService.ts ***!
  \*********************************************/
/*! exports provided: DataService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DataService", function() { return DataService; });
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs_add_operator_map__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs/add/operator/map */ "./node_modules/rxjs-compat/_esm5/add/operator/map.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



var DataService = /** @class */ (function () {
    function DataService(http) {
        this.http = http;
        this.parkings = []; /*type safety */
        this.landen = [];
        this.gemeentes = [];
        this.soorten = [];
    }
    DataService.prototype.loadParkings = function () {
        var _this = this;
        return this.http.get("/api/parkings") // hier de weg naar de apiom parkings op te halen
            .map(function (data) {
            _this.parkings = data;
            return true;
        });
    };
    ;
    DataService.prototype.loadLanden = function () {
        var _this = this;
        return this.http.get("/api/landen") // hier de weg naar de api om Landen op te halen
            .map(function (data) {
            _this.landen = data;
            return true;
        });
    };
    ;
    DataService.prototype.loadGemeentes = function () {
        var _this = this;
        return this.http.get("/api/gemeentes") // hier de weg naar de api om Landen op te halen
            .map(function (data) {
            _this.gemeentes = data;
            return true;
        });
    };
    ;
    DataService.prototype.loadSoorten = function () {
        var _this = this;
        return this.http.get("/api/soorts") // hier de weg naar de api om Landen op te halen
            .map(function (data) {
            _this.soorten = data;
            return true;
        });
    };
    ;
    DataService = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_0__["HttpClient"]])
    ], DataService);
    return DataService;
}());



/***/ }),

/***/ "./ClientApp/environments/environment.ts":
/*!***********************************************!*\
  !*** ./ClientApp/environments/environment.ts ***!
  \***********************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./ClientApp/main.ts":
/*!***************************!*\
  !*** ./ClientApp/main.ts ***!
  \***************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./ClientApp/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./ClientApp/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.log(err); });


/***/ }),

/***/ 0:
/*!*********************************!*\
  !*** multi ./ClientApp/main.ts ***!
  \*********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! D:\Benny\Documenten\Eindwerk\EindwerkCarParkingSolution\EindwerkCarParkingCore\ClientApp\main.ts */"./ClientApp/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map