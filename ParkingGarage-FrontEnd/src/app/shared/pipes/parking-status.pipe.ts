import { Pipe, PipeTransform } from '@angular/core';
import { ParkingStatus } from '../enums/parking-slot.model';

@Pipe({
  name: 'parkingStatus',
  standalone: true,
})
export class ParkingStatusPipe implements PipeTransform {
  transform(value: number | ParkingStatus): unknown {
    switch (value) {
      case 0:
        return 'Parking';
      case 1:
        return 'Left';
      default:
        return 'Unknown';
    }
  }
}
