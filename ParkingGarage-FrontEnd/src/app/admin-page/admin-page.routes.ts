import { Routes } from '@angular/router';
import { AdminPageComponent } from './admin-page.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { Authority } from '../shared/constants/authority.constants';
import { UserRouteAccessService } from '../core/auth/user-route-access.service';
import { VehicleManagementComponent } from './vehicle-management/vehicle-management.component';
import { TicketManagementComponent } from './ticket-management/ticket-management.component';

export const routes: Routes = [
  {
    path: '',
    component: AdminPageComponent,
    children: [
      {
        path: '',
        component: UserManagementComponent,
      },
      {
        path: 'user',
        component: UserManagementComponent,
        data: {
          authorities: [Authority.ADMIN],
        },
        canActivate: [UserRouteAccessService],
      },
      {
        path: 'floor',
        loadChildren: () =>
          import('./floor-management/floor-management.routes').then(
            (r) => r.routes
          ),
        data: {
          authorities: [Authority.ADMIN],
        },
        canActivate: [UserRouteAccessService],
      },
      {
        path: 'vehicle',
        component: VehicleManagementComponent
      },
      {
        path: 'ticket',
        component: TicketManagementComponent
      }
    ],
  },
];
