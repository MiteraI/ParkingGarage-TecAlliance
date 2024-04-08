import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationConfigService } from '../../core/config/application-config.service';
import { Observable } from 'rxjs';
import { CreateTicket } from '../models/createTicket.model';
import { ITicket } from '../models/ticket.model';

export type EntityResponseType = HttpResponse<ITicket>;
export type EntityArrayResponseType = HttpResponse<ITicket[]>;

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  private resourceUrl =
    this.applicationConfigService.getEndpointFor('/api/tickets');

  constructor(
    private http: HttpClient,
    private applicationConfigService: ApplicationConfigService
  ) {}

  checkActiveTicket(
    createTicket: CreateTicket
  ): Observable<EntityResponseType> {
    return this.http.post<ITicket>(`${this.resourceUrl}/check`, createTicket, {
      observe: 'response',
    });
  }

  createEnterTicket(
    createTicket: CreateTicket
  ): Observable<EntityResponseType> {
    return this.http.post<ITicket>(`${this.resourceUrl}/enter`, createTicket, {
      observe: 'response',
    });
  }

  createLeaveTicket(
    createTicket: CreateTicket
  ): Observable<EntityResponseType> {
    return this.http.post<ITicket>(`${this.resourceUrl}/exit`, createTicket, {
      observe: 'response',
    });
  }
}
