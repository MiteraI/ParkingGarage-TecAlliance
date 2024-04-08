import { Routes } from '@angular/router';
import { AdminPageComponent } from './admin-page.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { Authority } from '../shared/constants/authority.constants';
import { UserRouteAccessService } from '../core/auth/user-route-access.service';

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
        loadComponent: () =>
          import('./floor-management/floor-management.component').then(
            (c) => c.FloorManagementComponent
          ),
        data: {
          authorities: [Authority.ADMIN],
        },
        canActivate: [UserRouteAccessService],
      },
    ],
  },
];
