import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { SecurityPageComponent } from './security-page/security-page.component';
import { UserRouteAccessService } from './core/auth/user-route-access.service';
import { Authority } from './core/config/authority.constants';

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
    component: AdminPageComponent,
    title: 'Admin',
  },
  {
    path: 'security',
    data: {
      authorities: [Authority.ADMIN],
    },
    canActivate: [UserRouteAccessService],
    component: SecurityPageComponent,
    title: 'Security',
  },
];
