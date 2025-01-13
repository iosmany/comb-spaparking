

export interface ParkingPermit {
    id: number;
    parkingAreaId: number;
    parkingAreaName: string;
    effectiveDate: Date;
    expirationDate: Date;
    licensePlate: string;
    dateCreated: Date;
    inactive: boolean;
}

