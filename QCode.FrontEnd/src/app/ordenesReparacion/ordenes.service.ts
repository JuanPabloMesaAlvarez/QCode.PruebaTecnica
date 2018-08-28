import { Injectable } from "@angular/core";
import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { OrdenReparacion } from "../models/ordenReparacion";

@Injectable()
export class OrdenesService {

    constructor(private http: HttpHandlerService) {
    }

    traerOrdenes() {
        return this.http.get('OrdenesReparacion');
    }

    traerOrden(orden:number) {
        return this.http.get(`OrdenesReparacion/${orden}`);
    }

    crearOrden(orden:OrdenReparacion) {
        return this.http.post('OrdenesReparacion', orden);
    }

    retirarOrden(orden:number) {
        return this.http.delete(`OrdenesReparacion/${orden}`);
    }
}