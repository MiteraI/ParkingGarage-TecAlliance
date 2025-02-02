import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationConfigService } from '../../../core/config/application-config.service';
import { Observable } from 'rxjs';
import { Account } from '../../../core/auth/account.model';

export type EntityResponseType = HttpResponse<Account>;
export type EntityArrayResponseType = HttpResponse<Account[]>;

@Injectable({
  providedIn: 'root',
})
export class UserManagementService {
  private resourceUrl =
    this.applicationConfigService.getEndpointFor('/api/users');

  constructor(
    private http: HttpClient,
    private applicationConfigService: ApplicationConfigService
  ) {}

  getAll(req?: any): Observable<EntityArrayResponseType> {
    return this.http.get<Account[]>(this.resourceUrl, {
      observe: 'response',
    });
  }
}
