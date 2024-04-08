import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { SecurityPageComponent } from './security-page/security-page.component';
import { UserRouteAccessService } from './core/auth/user-route-access.service';
import { Authority } from './shared/constants/authority.constants';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    title: 'Login',
  },
  {
    path: 'admin',
    data: {
      authorities: [Authority.ADMIN],
    },
    canActivate: [UserRouteAccessService],
    loadChildren: () =>
      import('./admin-page/admin-page.routes').then((r) => r.routes),
    title: 'Admin page',
  },
  {
    path: 'security',
    data: {
      authorities: [Authority.SECURITY],
    },
    canActivate: [UserRouteAccessService],
    component: SecurityPageComponent,
    title: 'Security',
  },
];
