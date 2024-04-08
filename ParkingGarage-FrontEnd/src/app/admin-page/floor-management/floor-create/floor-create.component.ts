import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CreateFloor } from '../models/createFloor.model';
import { FloorManagementService } from '../service/floor-management.service';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { VehicleType } from '../../../shared/enums/vehicle-type.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-floor-create',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './floor-create.component.html',
  styleUrl: './floor-create.component.css',
})
export class FloorCreateComponent {
  floorForm: FormGroup;
  vehicleTypes = Object.values(VehicleType);

  constructor(
    private fb: FormBuilder,
    private floorService: FloorManagementService,
    private router: Router
  ) {
    this.floorForm = this.fb.group({
      slotPrice: [null, [Validators.required, Validators.min(5000)]],
      slotCount: [null, [Validators.required, Validators.min(5)]],
      physicalFloor: [null, [Validators.required, Validators.min(1)]],
      floorCode: [null, [Validators.required]],
      vehicleType: [null, [Validators.required]],
    });
  }

  onSubmit(): void {
    if (this.floorForm.invalid) {
      return;
    }

    if (this.floorForm.value.vehicleType == VehicleType.CAR) {
      this.floorForm.value.vehicleType = 0;
    } else {
      this.floorForm.value.vehicleType = 1;
    }

    const formData: CreateFloor = {
      slotPrice: this.floorForm.value.slotPrice,
      slotCount: this.floorForm.value.slotCount,
      physicalFloor: this.floorForm.value.physicalFloor,
      floorCode: this.floorForm.value.floorCode,
      floorType: this.floorForm.value.vehicleType,
    };

    this.floorService.create(formData).subscribe({
      next: (e) => {
        console.log(e);
        this.router.navigate(['/admin/floor']);
      },
      error: (e) => console.log(e),
    });
  }
}
