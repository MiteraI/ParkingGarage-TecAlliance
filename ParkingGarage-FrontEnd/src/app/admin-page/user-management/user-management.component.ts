import { Component } from '@angular/core';
import { UserManagementService } from './service/user-management.service';
import { Account } from '../../core/auth/account.model';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-user-management',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './user-management.component.html',
  styleUrl: './user-management.component.css',
})
export class UserManagementComponent {
  displayedColumns: string[] = [
    'authorities',
    'email',
    'firstName',
    'lastName',
    'login',
    'imageUrl',
  ];

  users: Account[] = [];

  constructor(private userService: UserManagementService) {
    userService.getAll().subscribe({
      next: (e) => (this.users = e.body == null ? [] : e.body),
    });
  }
}
