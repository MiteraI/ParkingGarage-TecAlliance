import { Injectable } from '@angular/core';
import { AccountService } from '../core/auth/account.service';
import { AuthJwtService } from '../core/auth/auth-jwt.service';
import { Observable, mergeMap } from 'rxjs';
import { Login } from './login.model';
import { Account } from '../core/auth/account.model';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(
    private accountService: AccountService,
    private authServerProvider: AuthJwtService
  ) {}

  login(credentials: Login): Observable<Account | null> {
    return this.authServerProvider
      .login(credentials)
      .pipe(mergeMap(() => this.accountService.identity(true)));
  }

  logout(): void {
    this.authServerProvider
      .logout()
      .subscribe({ complete: () => this.accountService.authenticate(null) });
  }
}
