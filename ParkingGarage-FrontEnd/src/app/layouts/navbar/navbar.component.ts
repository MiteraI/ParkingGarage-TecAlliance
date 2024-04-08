import { Component } from '@angular/core';
import { AccountService } from '../../core/auth/account.service';
import { Authority } from '../../core/config/authority.constants';
import { AuthJwtService } from '../../core/auth/auth-jwt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  accountRole: string = '';
  constructor(
    private accountService: AccountService,
    private authService: AuthJwtService,
    private router: Router
  ) {
    accountService.identity().subscribe((e) => {
      if (accountService.hasAnyAuthority(Authority.ADMIN)) {
        this.accountRole = 'ADMIN';
      }
      if (accountService.hasAnyAuthority(Authority.SECURITY)) {
        this.accountRole = 'SECURITY';
      }
    });
  }

  logout(): void {
    this.authService.logout().subscribe({
      complete: () => {
        this.accountService.authenticate(null);
        this.router.navigate(['login']);
      },
    });
  }
}
