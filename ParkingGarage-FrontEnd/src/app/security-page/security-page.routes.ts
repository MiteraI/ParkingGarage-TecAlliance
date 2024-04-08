import { Routes } from '@angular/router';
import { Authority } from '../shared/constants/authority.constants';
import { UserRouteAccessService } from '../core/auth/user-route-access.service';
import { SecurityPageComponent } from './security-page.component';
import { VehicleEnterComponent } from './vehicle-enter/vehicle-enter.component';
import { VehicleExitComponent } from './vehicle-exit/vehicle-exit.component';

export const routes: Routes = [
  {
    path: '',
    component: SecurityPageComponent,
    children: [
      {
        path: '',
        component: VehicleEnterComponent,
      },
      {
        path: 'vehicle-enter',
        component: VehicleEnterComponent,
      },
      {
        path: 'vehicle-exit',
        loadComponent: () =>
          import('./vehicle-exit/vehicle-exit.component').then(
            (c) => c.VehicleExitComponent
          ),
      },
    ],
  },
];
