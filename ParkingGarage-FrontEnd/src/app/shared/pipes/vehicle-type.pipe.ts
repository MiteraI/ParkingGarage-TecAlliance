import { Pipe, PipeTransform } from '@angular/core';
import { VehicleType } from '../enums/vehicle-type.model';

@Pipe({
  name: 'vehicleType',
  standalone: true,
})
export class VehicleTypePipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case 0:
        return 'Car';
      case 1:
        return 'Motorcycle';
      default:
        return 'Unknown';
    }
  }
}
