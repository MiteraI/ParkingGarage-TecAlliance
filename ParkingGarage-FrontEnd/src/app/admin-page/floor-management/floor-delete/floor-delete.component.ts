import { Component, Inject } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { IFloor } from '../models/floor.model';
import { FloorManagementService } from '../service/floor-management.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-floor-delete',
  standalone: true,
  imports: [MatButtonModule, MatButtonModule],
  templateUrl: './floor-delete.component.html',
  styleUrl: './floor-delete.component.css',
})
export class FloorDeleteComponent {
  floor: IFloor;
  constructor(
    public dialogRef: MatDialogRef<FloorDeleteComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IFloor,
    private floorService: FloorManagementService,
    private router: Router
  ) {
    this.floor = data;
  }

  cancel(): void {
    this.dialogRef.close();
  }

  confirmDelete(): void {
    this.floorService
      .delete(this.floor.id)
      .subscribe({
        next: () => this.dialogRef.close(true),
        error: () => this.dialogRef.close(true),
      });
  }
}
