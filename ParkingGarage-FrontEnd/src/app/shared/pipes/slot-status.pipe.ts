import { Pipe, PipeTransform } from '@angular/core';
import { SlotStatus } from '../enums/slot-status.model';

@Pipe({
  name: 'slotStatus',
  standalone: true
})
export class SlotStatusPipe implements PipeTransform {

  transform(value: number | SlotStatus): unknown {
    switch (value) {
      case 0:
        return 'Occupied';
      case 1:
        return 'Vacant';
      default:
        return 'Unknown';
    }
  }

}
