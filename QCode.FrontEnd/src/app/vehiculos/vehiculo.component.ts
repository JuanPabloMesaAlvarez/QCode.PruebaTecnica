import { Component, Input, OnChanges, SimpleChanges, Output, EventEmitter } from "@angular/core";
import { VehiculosService } from "./vehiculos.service";
import { Vehiculo } from "../models/vehiculo";

@Component({
    selector: 'vehiculo',
    templateUrl: './vehiculo.component.html',
    providers: [VehiculosService]
})

export class VehiculoComponent implements OnChanges {

    @Input() placa: string = "";
    @Output() vehiculoCreado = new EventEmitter();

    vehiculo: Vehiculo = new Vehiculo();
    fileList: FileList;
    image: string = "";

    constructor(private service: VehiculosService) {
    }

    ngOnChanges(changes: SimpleChanges): void {
        if (changes["placa"].previousValue === changes["placa"].currentValue) {
            return;
        }

        if (changes["placa"].currentValue === "") {
            this.vehiculo = new Vehiculo();
            return;
        }

        this.service.traerVehiculo(this.placa).subscribe(
            (result: Vehiculo) => {
                this.vehiculo = result;
                this.image = 'data:image/png;base64,' + this.vehiculo.Imagen;
            },
            error => {
                console.log(error.error.ExceptionMessage);
            }
        );
    }

    guardarVehiculo() {
        if (this.placa === "") {
            this.service.crearVehiculo(this.vehiculo).subscribe(
                result => { this.vehiculoCreado.emit(); },
                error => { console.error(error.error.ExceptionMessage); }
            );
            return;
        }

        this.service.actualizarVehiculo(this.vehiculo).subscribe(
            result => { this.vehiculoCreado.emit(); },
            error => { console.error(error.error.ExceptionMessage); }

        );
    }

    fileChange(event: any) {
        this.fileList = event.target.files;
        if (this.fileList.length > 0) {
            this.service.importarImagen(this.fileList[0]).subscribe(
                result => {
                    this.vehiculo.Imagen = result;
                    this.image = 'data:image/png;base64,' + this.vehiculo.Imagen;
                },
                error => {
                    console.log(error.error.ExceptionMessage);
                }
            );
        }
    }
}