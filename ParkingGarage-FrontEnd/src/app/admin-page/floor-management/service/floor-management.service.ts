import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationConfigService } from '../../../core/config/application-config.service';
import { CreateFloor } from '../models/createFloor.model';
import { Observable } from 'rxjs';
import { IFloor } from '../models/floor.model';

export type EntityResponseType = HttpResponse<IFloor>;
export type EntityArrayResponseType = HttpResponse<IFloor[]>;

@Injectable({
  providedIn: 'root',
})
export class FloorManagementService {
  private resourceUrl =
    this.applicationConfigService.getEndpointFor('/api/floors');

  constructor(
    private http: HttpClient,
    private applicationConfigService: ApplicationConfigService
  ) {}

  create(floor: CreateFloor): Observable<EntityResponseType> {
    return this.http.post<IFloor>(this.resourceUrl, floor, {
      observe: 'response',
    });
  }

  getAll(req?: any): Observable<EntityArrayResponseType> {
    return this.http.get<IFloor[]>(this.resourceUrl, {
      observe: 'response',
    });
  }

  getOne(id: number): Observable<EntityResponseType> {
    return this.http.get<IFloor>(`${this.resourceUrl}/${id}`, {
      observe: 'response',
    });
  }

  delete(id: number): Observable<EntityResponseType> {
    return this.http.delete<IFloor>(`${this.resourceUrl}/${id}`, {
      observe: 'response',
    });
  }
}
