import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { VehiculosService } from "./vehiculos.service";
import { Vehiculo } from "../models/vehiculo";

@Component({
    selector: 'vehiculos',
    templateUrl: './vehiculos.component.html',
    providers: [VehiculosService]
})

export class VehiculosComponent implements OnInit {

    vehiculos: Vehiculo[] = [];
    fileList: FileList;
    placaSeleccionada: string = "";

    constructor(private service: VehiculosService, private router: Router) {
    }

    ngOnInit(): void {
        this.traerVehiculos();
    }

    traerVehiculos(){
        this.service.traerVehiculos().subscribe(
            (result: Vehiculo[]) => { this.vehiculos = result },
            error => { console.log(error); }
        );
    }

    crearVehiculo(){
     this.placaSeleccionada = "";  
    }

    seleccionarVehiculo(placa: string){
        this.placaSeleccionada = placa;
    }

    fileChange(event: any) {
        this.fileList  = event.target.files;
    }

    importarVehiculos(){
        if (this.fileList.length > 0) {
            this.service.importarVehiculos(this.fileList[0]).subscribe(
                result => {
                    this.traerVehiculos();
                },
                error => {
                    console.log(error.error.ExceptionMessage);
                }
            );
        }
    }
}