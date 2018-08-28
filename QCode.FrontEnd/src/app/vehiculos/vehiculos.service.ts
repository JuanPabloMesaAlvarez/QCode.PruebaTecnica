import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { Injectable } from "@angular/core";
import { Vehiculo } from "../models/vehiculo";
import { HttpHeaders } from "@angular/common/http";

@Injectable()
export class VehiculosService {
    
    constructor(private http: HttpHandlerService) {
 
    }

    traerVehiculos(){
        var uri = "vehiculos";
        return this.http.get(uri);
    }

    traerVehiculo(placa: string){
        var uri = `vehiculos/${placa}`;
        return this.http.get(uri);
    }

    crearVehiculo(vehiculo: Vehiculo){
        var uri = "vehiculos";
        return this.http.post(uri, vehiculo);
    }

    actualizarVehiculo(vehiculo: Vehiculo){
        var uri = `vehiculos/${vehiculo.Placa}`;
        return this.http.put(uri, vehiculo);
    }

    importarVehiculos(file: File){
        var uri = 'importaciones';
        return this.importar(uri, file);
    }

    importarImagen(file: File){
        var uri = 'imagenes';
        return this.importar(uri, file);
    }

    importar(uri: string, file:File){
        let formData: FormData = new FormData();
        formData.append('uploadFile', file, file.name);
        var headers: HttpHeaders = new HttpHeaders();
        return this.http.post(uri, formData);
    }
}