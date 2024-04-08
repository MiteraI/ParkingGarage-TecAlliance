import { Component } from '@angular/core';
import { FloorManagementService } from './service/floor-management.service';
import { IFloor } from './models/floor.model';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { VehicleTypePipe } from '../../shared/pipes/vehicle-type.pipe';
import { FloorDeleteComponent } from './floor-delete/floor-delete.component';

@Component({
  selector: 'app-floor-management',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatButtonModule,
    MatDialogModule,
    VehicleTypePipe,
  ],
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
    'delete'
  ];

  floors: IFloor[] = [];

  constructor(private floorService: FloorManagementService, private dialog: MatDialog) {
    floorService.getAll().subscribe((response) => {
      this.floors = response.body == null ? [] : response.body;
    });
  }

  openDeleteDialog(floor: IFloor): void {
    const dialogRef = this.dialog.open(FloorDeleteComponent, {
      minWidth: '450px', 
      data: floor
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        // If result is true, it means user confirmed deletion
        // Add logic to delete the floor here
      }
    });
  }
}
