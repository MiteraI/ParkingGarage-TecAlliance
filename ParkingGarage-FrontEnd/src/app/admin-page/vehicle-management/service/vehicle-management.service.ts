import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationConfigService } from '../../../core/config/application-config.service';
import { IVehicle } from '../models/vehicle.model';
import { Observable } from 'rxjs';

export type EntityResponseType = HttpResponse<IVehicle>;
export type EntityArrayResponseType = HttpResponse<IVehicle[]>;

@Injectable({
  providedIn: 'root',
})
export class VehicleManagementService {
  private resourceUrl =
    this.applicationConfigService.getEndpointFor('/api/vehicles');

  constructor(
    private http: HttpClient,
    private applicationConfigService: ApplicationConfigService
  ) {}

  getAll(req?: any): Observable<EntityArrayResponseType> {
    return this.http.get<IVehicle[]>(this.resourceUrl, {
      observe: 'response',
    });
  }
}
