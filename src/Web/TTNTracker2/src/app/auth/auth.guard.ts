import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private jwtHelper: JwtHelperService) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    var token = localStorage.getItem("token");
    if (token != null && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }
  }

}
