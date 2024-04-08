import { VehicleType } from "../../../shared/enums/vehicle-type.model";

export interface CreateFloor{
    slotPrice: number,
    slotCount: number,
    physicalFloor: number,
    floorCode: string,
    floorType: VehicleType | number
}