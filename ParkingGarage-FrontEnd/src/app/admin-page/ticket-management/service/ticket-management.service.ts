import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationConfigService } from '../../../core/config/application-config.service';
import { ITicket } from '../../../security-page/models/ticket.model';
import { Observable } from 'rxjs';

export type EntityResponseType = HttpResponse<ITicket>;
export type EntityArrayResponseType = HttpResponse<ITicket[]>;

@Injectable({
  providedIn: 'root',
})
export class TicketManagementService {
  private resourceUrl =
    this.applicationConfigService.getEndpointFor('/api/tickets');

  constructor(
    private http: HttpClient,
    private applicationConfigService: ApplicationConfigService
  ) {}

  getAll(req?: any): Observable<EntityArrayResponseType> {
    return this.http.get<ITicket[]>(this.resourceUrl, {
      observe: 'response',
    });
  }
}
