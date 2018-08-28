import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Usuario } from '../../models/usuario';

@Injectable()
export class GuardRoute implements CanActivate {

    usuario: Usuario;
    asignarUsuario(usuario: Usuario) {
        this.usuario = usuario;
        localStorage.setItem('usr', JSON.stringify(this.usuario));
    }

    canActivate(): boolean {
        if(!this.usuario && !localStorage.getItem('usr')){
            return false;
        }

        if (!this.usuario) {
            this.usuario = JSON.parse(localStorage.getItem('usr'));
        }

        return this.usuario.IsValid;
    }

}