import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';
import { SlotStatusPipe } from '../../shared/pipes/slot-status.pipe';
import { TicketStatusPipe } from '../../shared/pipes/ticket-status.pipe';
import { ITicket } from '../models/ticket.model';
import { TicketService } from '../service/ticket.service';
import { CreateTicket } from '../models/createTicket.model';

@Component({
  selector: 'app-vehicle-exit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    SlotStatusPipe,
    VehicleTypePipe,
    TicketStatusPipe,
  ],
  templateUrl: './vehicle-exit.component.html',
  styleUrl: './vehicle-exit.component.css',
})
export class VehicleExitComponent {
  form: FormGroup;
  ticket: ITicket | null = null;
  paidTicket: boolean = false;
  plateType: string = '';

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

  payTicket(): void {
    const createTicket: CreateTicket = {
      licensePlateNumber: this.form.value.licensePlateNumber,
    };

    this.ticketService.createLeaveTicket(createTicket).subscribe({
      next: (e) => {
        this.ticket = e.body;
        this.paidTicket = true;
        console.log(e.body);
      },
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      const createTicket: CreateTicket = {
        licensePlateNumber: this.form.value.licensePlateNumber,
      };
      this.ticketService.checkActiveTicket(createTicket).subscribe({
        next: (e) => {
          this.ticket = e.body;
          console.log(e.body);
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
