import { Component, Input, Output, OnChanges, SimpleChanges, EventEmitter } from "@angular/core";
import { OrdenesService } from "./ordenes.service";
import { OrdenReparacion } from "../models/ordenReparacion";
@Component({
    selector: 'orden',
    templateUrl: './orden.component.html',
    providers: [OrdenesService]
})
export class OrdenComponent implements OnChanges 
{
    @Input() ordenId: number = -1;
    @Output() ordenCreada = new EventEmitter();

    orden: OrdenReparacion = new OrdenReparacion();

    constructor(private service: OrdenesService) {
    }
    
    ngOnChanges(changes: SimpleChanges): void {
        if (changes["ordenId"].previousValue === changes["ordenId"].currentValue) {
            return;
        }

        if (changes["ordenId"].currentValue === -1) {
            this.orden = new OrdenReparacion();
            return;
        }

        this.service.traerOrden(this.ordenId).subscribe(
            (result: OrdenReparacion) => {
                this.orden = result;
            },
            error => {
                console.log(error.error.ExceptionMessage);
            }
        );
    }

    guardarOrden() {
        if (this.ordenId === -1) {
            this.service.crearOrden(this.orden).subscribe(
                (result: OrdenReparacion) => { 
                    this.orden = result;
                    this.ordenCreada.emit(); 
                },
                error => { console.error(error.error.ExceptionMessage); }
            );
            return;
        }
    }
}