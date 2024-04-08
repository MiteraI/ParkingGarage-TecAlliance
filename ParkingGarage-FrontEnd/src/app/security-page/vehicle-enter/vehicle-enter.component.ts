import { Component } from '@angular/core';
import { TicketService } from '../service/ticket.service';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CreateTicket } from '../models/createTicket.model';
import { ITicket } from '../models/ticket.model';
import { SlotStatusPipe } from '../../shared/pipes/slot-status.pipe';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';
import { TicketStatusPipe } from '../../shared/pipes/ticket-status.pipe';

@Component({
  selector: 'app-vehicle-enter',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    SlotStatusPipe,
    VehicleTypePipe,
    TicketStatusPipe
  ],
  templateUrl: './vehicle-enter.component.html',
  styleUrl: './vehicle-enter.component.css',
})
export class VehicleEnterComponent {
  form: FormGroup;
  plateType: string = '';
  ticket: ITicket | null = null

  constructor(
    private formBuilder: FormBuilder,
    private ticketService: TicketService
  ) {
    this.form = this.formBuilder.group({
      licensePlateNumber: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^(?:[A-Z]{2}[0-9]{4}|[A-Z]{1}[0-9]{5}|[A-Z]{2}[0-9]{3}[A-Z]{2})$/
          ),
        ],
      ],
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      const createTicket: CreateTicket = {
        licensePlateNumber: this.form.value.licensePlateNumber,
      };
      this.ticketService.createEnterTicket(createTicket).subscribe({
        next: (e) => {this.ticket = e.body; console.log(e.body);
        },
      });
    }
  }

  onLicensePlateChange(): void {
    const plateNumber = this.form.value.licensePlateNumber;
    if (/^[A-Z]{2}[0-9]{3}[A-Z]{2}$/.test(plateNumber)) {
      this.plateType = 'Car';
    } else if (/^(?:[A-Z]{2}[0-9]{4}|[A-Z]{1}[0-9]{5})$/.test(plateNumber)) {
      this.plateType = 'Motorcycle';
    } else {
      this.plateType = 'Unknown';
    }
  }
}
