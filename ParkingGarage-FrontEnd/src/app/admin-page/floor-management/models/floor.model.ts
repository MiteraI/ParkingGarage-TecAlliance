import { VehicleType } from "../../../shared/enums/vehicle-type.model";
import { IParkingSlot } from "./parkingSlot.model";

export interface IFloor {
    id: number,
    physicalFloor: number,
    floorCode: string,
    floorType: VehicleType,
    parkingSlots: IParkingSlot[]
}