import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StateStorageService } from './state-storage.service';
import { ApplicationConfigService } from '../config/application-config.service';
import { Observable, map } from 'rxjs';
import { Login } from '../../login/login.model';

type JwtToken = {
  jwt: string;
};

@Injectable({
  providedIn: 'root',
})
export class AuthJwtService {
  constructor(
    private http: HttpClient,
    private stateStorageService: StateStorageService,
    private applicationConfigService: ApplicationConfigService
  ) {}

  getToken(): string {
    return this.stateStorageService.getAuthenticationToken() ?? '';
  }

  login(credentials: Login): Observable<void> {
    return this.http
      .post<JwtToken>(
        this.applicationConfigService.getEndpointFor('/api/authenticate'),
        credentials
      )
      .pipe(map((response) => this.authenticateSuccess(response)));
  }

  logout(): Observable<void> {
    return new Observable((observer) => {
      this.stateStorageService.clearAuthenticationToken();
      observer.complete();
    });
  }

  private authenticateSuccess(response: JwtToken): void {
    this.stateStorageService.storeAuthenticationToken(response.jwt);
  }
}
