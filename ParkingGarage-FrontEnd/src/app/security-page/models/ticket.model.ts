import { IParkingSlot } from "../../admin-page/floor-management/models/parkingSlot.model";
import { TicketStatus } from "../../shared/enums/ticket-status.model";
import { VehicleType } from "../../shared/enums/vehicle-type.model";

export interface ITicket {
    parkTime: Date |null,
    leaveTime: Date | null,
    ticketFee: number | null,
    status: TicketStatus,
    vehicleType: VehicleType,
    vehicleId: string,
    parkingSlotId: number
    parkingSlot: IParkingSlot
}