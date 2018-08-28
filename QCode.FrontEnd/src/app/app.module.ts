import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

import { HttpHandlerService } from "./Utils/httpHandler/httpHandler.service";
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";
import { VehiculosComponent } from "./vehiculos/vehiculos.component";
import { OrdenesComponent } from "./ordenesReparacion/ordenes.component";

import { AppComponent } from './app.component';
import { httpInterceptorProviders } from './Utils/httpHandler/httpInterceptor.service';
import { appRoutes } from './Utils/routes/routes';
import { VehiculoComponent } from './vehiculos/vehiculo.component';
import { OrdenComponent } from "./ordenesReparacion/orden.component";
import { GuardRoute } from './Utils/routes/guardRoute';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    VehiculosComponent,
    VehiculoComponent,
    OrdenesComponent,
    OrdenComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    )
  ],
  providers: [HttpHandlerService,
    httpInterceptorProviders,
    GuardRoute],
  bootstrap: [AppComponent]
})
export class AppModule { }
