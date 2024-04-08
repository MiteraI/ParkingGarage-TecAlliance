import { Component } from '@angular/core';
import { FloorManagementService } from './service/floor-management.service';
import { IFloor } from './models/floor.model';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';


@Component({
  selector: 'app-floor-management',
  standalone: true,
  imports: [CommonModule, RouterModule, MatTableModule, MatButtonModule, VehicleTypePipe],
  templateUrl: './floor-management.component.html',
  styleUrl: './floor-management.component.css',
})
export class FloorManagementComponent {
  displayedColumns: string[] = [
    'id',
    'physicalFloor',
    'floorCode',
    'vehicleType',
    'details',
  ];

  floors: IFloor[] = [];

  constructor(private floorService: FloorManagementService) {
    floorService.getAll().subscribe((response) => {
      this.floors = response.body == null ? [] : response.body;      
    });
  }
}
