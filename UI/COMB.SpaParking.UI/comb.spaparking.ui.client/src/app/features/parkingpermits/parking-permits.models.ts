

export interface ParkingPermit {
    id: number;
    parkingAreaId: number;
    parkingAreaName: number;
    effectiveDate: Date;
    expirationDate: Date;
    licensePlate: string;
    dateCreated: Date;
    inactive: boolean;
}

