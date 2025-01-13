import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, of } from "rxjs";
import { ApiResponse } from "../../api/api.models";
import { ParkingPermit } from "./parking-permits.models";

@Injectable({
    providedIn: 'root'
})
export class ParkingPermitService {

    constructor(private http: HttpClient) {
    }

    getParkingPermits(page: number=0, length: number=10, byPlate: string | null= null, selectedExpiredStatus: boolean | null = null) {
        const skip = page * length;
        let queryPath = byPlate ? `/api/v1/parkingpermits?skip=${skip}&length=${length}&bylicenseplate=${byPlate}` : `/api/v1/parkingpermits?skip=${skip}&length=${length}`;
        queryPath = selectedExpiredStatus ? `${queryPath}&expired=${selectedExpiredStatus}` : queryPath;
        return this.http.get<ApiResponse<ParkingPermit[]>>(queryPath)
            .pipe(
                map((response: ApiResponse<ParkingPermit[]>) => {
                    return response.data;
                }),
                catchError((error) => {
                    console.error('Error fetching parking Permit', error);
                    return [];
                })
        )
    }

    getParkingPermitById(id: number) {
        return this.http.get<ApiResponse<ParkingPermit>>(`/api/v1/parkingpermits/${id}`)
            .pipe(
                map((response: ApiResponse<ParkingPermit>) => {
                    return response.data;
                }),
                catchError((error) => {
                    console.error('Error fetching parking Permit', error);
                    return of(null);
                })
            );
    }

    deactivateParkingPermit(id: number) {
        return this.http.put<ApiResponse<ParkingPermit>>(`/api/v1/parkingpermits/${id}/deactivate`, {})
            .pipe(
                catchError((error) => {
                    console.error('Error deactivating parking Permit', error);
                    return of(null);
                })
            );
    }
}