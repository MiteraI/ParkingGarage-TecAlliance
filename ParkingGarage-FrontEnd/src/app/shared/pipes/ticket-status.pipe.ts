import { Pipe, PipeTransform } from '@angular/core';
import { TicketStatus } from '../enums/ticket-status.model';

@Pipe({
  name: 'ticketStatus',
  standalone: true,
})
export class TicketStatusPipe implements PipeTransform {
  transform(value: number | TicketStatus): unknown {
    switch (value) {
      case 0:
        return 'Active';
      case 1:
        return 'Paid';
      default:
        return 'Lost';
    }
  }
}
