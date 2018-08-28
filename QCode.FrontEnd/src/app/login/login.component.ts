import { Component } from "@angular/core";
import { LoginService } from "./login.service";
import { Usuario } from "../models/usuario";
import { Router } from "@angular/router";
import { GuardRoute } from "../Utils/routes/guardRoute";

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    providers: [LoginService]
})

export class LoginComponent {

    usuario: Usuario = new Usuario();
    error: string = undefined;

    constructor(private service: LoginService, private router: Router, private guardRoute: GuardRoute) {
    }

    logIn() {
        this.service.logIn(this.usuario).subscribe(
            (result: Usuario) => {
                this.usuario = result;
                if (this.usuario.IsValid) {
                    this.guardRoute.asignarUsuario(this.usuario);
                    this.router.navigate(['/home']);
                }
            },
            error => {
                console.log(error);
                this.error = error.error.ExceptionMessage;
            }
        );
    }
}