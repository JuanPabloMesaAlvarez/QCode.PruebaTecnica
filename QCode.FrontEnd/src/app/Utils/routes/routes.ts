import { Routes } from "@angular/router";

import { LoginComponent } from "../../login/login.component";
import { VehiculosComponent } from "../../vehiculos/vehiculos.component";
import { HomeComponent } from "../../home/home.component";
import { OrdenesComponent } from "../../ordenesReparacion/ordenes.component";
import { GuardRoute } from "./guardRoute";

export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: 'home', component: HomeComponent, canActivate: [GuardRoute],
        children: [
            {
                path: 'vehiculos', component: VehiculosComponent,
            },
            {
                path: 'ordenes', component: OrdenesComponent,
            }
        ]
    },
    {
        path: '',
        redirectTo: '/login',
        pathMatch: 'full'
    },
    { path: '**', component: LoginComponent }
];