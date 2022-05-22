import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/services/authentication.service";

@Injectable()
export class CanActivateAdmin implements CanActivate {
  constructor(private authService: AuthenticationService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree {
    return this.authService.isUserAdmin();
  }
}