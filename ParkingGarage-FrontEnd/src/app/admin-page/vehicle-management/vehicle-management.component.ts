import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';
import { IVehicle } from './models/vehicle.model';
import { VehicleManagementService } from './service/vehicle-management.service';
import { ParkingStatusPipe } from '../../shared/pipes/parking-status.pipe';

@Component({
  selector: 'app-vehicle-management',
  standalone: true,
  imports: [MatTableModule, VehicleTypePipe, ParkingStatusPipe],
  templateUrl: './vehicle-management.component.html',
  styleUrl: './vehicle-management.component.css',
})
export class VehicleManagementComponent {
  displayedColumns: string[] = ['id', 'vehicleType', 'parkingStatus'];
  vehicles: IVehicle[] = [];

  constructor(private vehicleService: VehicleManagementService) {
    vehicleService.getAll().subscribe({
      next: (e) => (this.vehicles = e.body == null ? [] : e.body),
    });
  }
}
