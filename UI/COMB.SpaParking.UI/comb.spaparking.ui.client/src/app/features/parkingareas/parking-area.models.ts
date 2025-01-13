
export interface ParkingAreaType {
    id: number;
    parkingAreaTypeDescription: string;
    inactive: boolean;
}

export interface ParkingArea {

    id: number;
    parkingAreaTypeId: number;
    parkingAreaTypeDescription: string;
    parkingAreaName: string;
    latitude: number;
    longitude: number;
    dateCreated: Date;
    inactive: boolean;
}
