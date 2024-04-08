import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { TicketManagementService } from './service/ticket-management.service';
import { ITicket } from '../../security-page/models/ticket.model';
import { DatePipe } from '@angular/common';
import { TicketStatusPipe } from '../../shared/pipes/ticket-status.pipe';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';

@Component({
  selector: 'app-ticket-management',
  standalone: true,
  imports: [MatTableModule, DatePipe, TicketStatusPipe, VehicleTypePipe],
  templateUrl: './ticket-management.component.html',
  styleUrl: './ticket-management.component.css',
})
export class TicketManagementComponent {
  displayedColumns: string[] = [
    'parkTime',
    'leaveTime',
    'ticketFee',
    'status',
    'vehicleType',
    'vehicleId',
    'parkingSlotId',
  ];

  tickets: ITicket[] = [];

  constructor(private ticketService: TicketManagementService) {
    ticketService
      .getAll()
      .subscribe((e) => (this.tickets = e.body == null ? [] : e.body));
  }
}
