import { Routes } from '@angular/router';
import { Authority } from '../../shared/constants/authority.constants';
import { UserRouteAccessService } from '../../core/auth/user-route-access.service';
import { FloorManagementComponent } from './floor-management.component';
import { FloorDetailsComponent } from './floor-details/floor-details.component';
import floorResolve from './service/floor-routing-resolve.service';
import { FloorCreateComponent } from './floor-create/floor-create.component';

export const routes: Routes = [
  {
    path: '',
    component: FloorManagementComponent,
    canActivate: [UserRouteAccessService],
  },
  {
    path: 'create',
    component: FloorCreateComponent,
    canActivate: [UserRouteAccessService],
  },
  {
    path: 'view/:id',
    component: FloorDetailsComponent,
    resolve: {
      floor: floorResolve,
    },
    canActivate: [UserRouteAccessService],
  },
];
