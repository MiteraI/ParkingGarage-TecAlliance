import { ParkingStatus } from "../../../shared/enums/parking-slot.model";
import { VehicleType } from "../../../shared/enums/vehicle-type.model";

export interface IVehicle {
    id: string,
    type: VehicleType,
    parkingStatus: ParkingStatus
}