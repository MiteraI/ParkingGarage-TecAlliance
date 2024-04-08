import { Component } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-security-page',
  standalone: true,
  imports: [RouterModule, RouterOutlet ,MatSidenavModule],
  templateUrl: './security-page.component.html',
  styleUrl: './security-page.component.css'
})
export class SecurityPageComponent {

}
