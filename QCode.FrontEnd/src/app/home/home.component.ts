import { Component } from "@angular/core";
import { Router } from "../../../node_modules/@angular/router";
import { GuardRoute } from "../Utils/routes/guardRoute";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent {
    
    constructor(private router: Router, private guardRoute: GuardRoute) {
        
    }

    logOut(){
        this.guardRoute = new GuardRoute();
        localStorage.removeItem('usr');
        this.router.navigate(['/login']);
    }
}