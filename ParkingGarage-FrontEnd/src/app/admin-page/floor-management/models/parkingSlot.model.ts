import { SlotStatus } from "../../../shared/enums/slot-status.model";

export interface IParkingSlot {
    id: number,
    pricePerHour: number,
    slotCode: string,
    status: SlotStatus
}