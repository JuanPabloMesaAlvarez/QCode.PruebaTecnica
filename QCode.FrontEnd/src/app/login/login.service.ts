import { HttpHandlerService } from "../Utils/httpHandler/httpHandler.service";
import { Injectable } from "@angular/core";
import { Usuario } from "../models/usuario";

@Injectable()
export class LoginService {

    constructor(private http: HttpHandlerService) {
    }

    logIn(usuario: Usuario) {
        return this.http.post("login", usuario);
    }

}