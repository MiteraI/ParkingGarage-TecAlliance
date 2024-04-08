import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './layouts/navbar/navbar.component';
import { AccountService } from './core/auth/account.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'ParkingGarage-FrontEnd';

  constructor(private accountService: AccountService, private router: Router) {
    this.accountService.identity().subscribe(() => {
      if (!this.accountService.isAuthenticated()) {
        this.router.navigate(['login']);
      }
    });
  }
}
