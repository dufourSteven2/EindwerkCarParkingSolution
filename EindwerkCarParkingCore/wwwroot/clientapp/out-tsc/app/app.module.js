"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_1 = require("@angular/platform-browser");
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http"); //////////////
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var ParkingList_component_1 = require("./ParkingLijst/ParkingList.component");
var dataService_1 = require("./shared/dataService");
var googleMap_Component_1 = require("./shared/googleMap.Component");
var Landen_Component_1 = require("./Landen/Landen.Component");
var Gemeente_Component_1 = require("./Gemeentes/Gemeente.Component");
var Soorten_Component_1 = require("./Soorten/Soorten.Component");
var core_2 = require("@agm/core");
var GeocodingApiService_1 = require("./Services/GeocodingApiService");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            declarations: [
                app_component_1.AppComponent,
                ParkingList_component_1.ParkingList,
                Landen_Component_1.Landen,
                Gemeente_Component_1.Gemeentes,
                Soorten_Component_1.Soorten,
                googleMap_Component_1.googleMapComponent,
            ],
            imports: [
                platform_browser_1.BrowserModule,
                forms_1.FormsModule,
                http_1.HttpClientModule,
                core_2.AgmCoreModule.forRoot({
                    apiKey: 'AIzaSyCeiTZY7jXETj0MpKuUbKwN_CqeUzv0v-M'
                }),
            ],
            providers: [
                dataService_1.DataService,
                GeocodingApiService_1.GeocodingApiService
            ],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map