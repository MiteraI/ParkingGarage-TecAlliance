import { Component } from '@angular/core';
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './layouts/navbar/navbar.component';
import { AccountService } from './core/auth/account.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Authority } from './shared/constants/authority.constants';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'ParkingGarage-FrontEnd';
  showNavbar = false;
  constructor(private accountService: AccountService, private router: Router) {
     this.router.events.subscribe((event) => {
       if (event instanceof NavigationEnd) {
          if (event.url.includes('/login')) {
            this.showNavbar = false;
         } else {
            this.showNavbar = true;
         }
       }
     });
    
    this.accountService.identity().subscribe((e) => {
      if (!this.accountService.isAuthenticated()) {
        this.router.navigate(['login']);
      }

      if (accountService.hasAnyAuthority([Authority.ADMIN]))
        this.router.navigate(['admin']);
      if (accountService.hasAnyAuthority([Authority.SECURITY]))
        this.router.navigate(['security'])
    });
  }
}
