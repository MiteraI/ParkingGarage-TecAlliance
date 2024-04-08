import { Component, Input, OnInit } from '@angular/core';
import { IFloor } from '../models/floor.model';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { VehicleTypePipe } from '../../../shared/pipes/vehicle-type.pipe';
import { IParkingSlot } from '../models/parkingSlot.model';
import { SlotStatusPipe } from '../../../shared/pipes/slot-status.pipe';

@Component({
  selector: 'app-floor-details',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatButtonModule,
    VehicleTypePipe,
    SlotStatusPipe
  ],
  templateUrl: './floor-details.component.html',
  styleUrl: './floor-details.component.css',
})
export class FloorDetailsComponent implements OnInit {
  @Input() floor: IFloor | null = null;
  displayedColumns: string[] = ['id', 'pricePerHour', 'slotCode', 'status'];

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.data.subscribe((data) => {
      this.floor = data['floor'];
    });
  }
}
