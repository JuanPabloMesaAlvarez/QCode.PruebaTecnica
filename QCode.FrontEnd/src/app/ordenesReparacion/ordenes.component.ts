import { Component, OnInit } from "@angular/core";
import { OrdenesService } from "./ordenes.service";
import { OrdenReparacion } from "../models/ordenReparacion";

@Component({
    selector: 'ordenes',
    templateUrl: 'ordenes.component.html',
    providers: [OrdenesService]
})

export class OrdenesComponent implements OnInit {
    
    ordenes: OrdenReparacion[] = [];
    ordenSeleccionada: number = -1;

    constructor(private service: OrdenesService) {
    }

    ngOnInit(): void {
        this.traerOrdenes();
    }

    traerOrdenes(): any {
        this.service.traerOrdenes().subscribe(
            (result: OrdenReparacion[]) => {
                this.ordenes = result;
            },
            error => {
                console.log(error.error.ExceptionMessage)
            }
        )
    }

    crearOrden(){
        this.ordenSeleccionada = -1;
    }

    seleccionarOrden(ordenId: number){
        this.ordenSeleccionada = ordenId;
    }

    eliminarOrden(ordenId: number){
        this.service.retirarOrden(ordenId).subscribe(
            result => { this.traerOrdenes(); },
            error => { console.log(error.error.ExceptionMessage); }
        );
    }
}