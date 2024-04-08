import { Routes } from '@angular/router';
import { Authority } from '../shared/constants/authority.constants';
import { UserRouteAccessService } from '../core/auth/user-route-access.service';
import { SecurityPageComponent } from './security-page.component';

export const routes: Routes = [
  {
    path: '',
    component: SecurityPageComponent,
    children: [
      // {
      //   path: '',
      //   component: UserManagementComponent,
      // },
      // {
      //   path: 'user',
      //   component: UserManagementComponent,
      //   data: {
      //     authorities: [Authority.ADMIN],
      //   },
      //   canActivate: [UserRouteAccessService],
      // },
      // {
      //   path: 'floor',
      //   loadComponent: () =>
      //     import('./floor-management/floor-management.component').then(
      //       (c) => c.FloorManagementComponent
      //     ),
      //   data: {
      //     authorities: [Authority.ADMIN],
      //   },
      //   canActivate: [UserRouteAccessService],
      // },
    ],
  },
];
