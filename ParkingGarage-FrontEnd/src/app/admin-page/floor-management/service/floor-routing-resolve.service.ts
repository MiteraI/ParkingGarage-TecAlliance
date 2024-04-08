import { inject } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { ActivatedRouteSnapshot, Router } from '@angular/router';
import { of, EMPTY, Observable } from 'rxjs';
import { mergeMap } from 'rxjs/operators';
import { FloorManagementService } from './floor-management.service';
import { IFloor } from '../models/floor.model';


export const floorResolve = (route: ActivatedRouteSnapshot): Observable<null | IFloor> => {
  const id = route.params['id'];
  if (id) {
    return inject(FloorManagementService)
      .getOne(id)
      .pipe(
        mergeMap((floor: HttpResponse<IFloor>) => {
          if (floor.body) {
            return of(floor.body);
          } else {
            inject(Router).navigate(['404']);
            return EMPTY;
          }
        }),
      );
  }
  return of(null);
};

export default floorResolve;
