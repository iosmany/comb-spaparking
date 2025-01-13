import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map } from "rxjs";
import { ApiResponse } from "../../api/api.models";
import { ParkingArea } from "./parking-area.models";

export interface FilterParkingAreas {
    getParkingAreas(page: number, length: number): any;
}

@Injectable({
    providedIn: 'root'
})
export class ParkingAreaService {

    constructor(private http: HttpClient) {
    }

    getParkingAreas(page:number=0, length:number=10, parkingAreaTypeId:number= 0) {
        const skip = page * length;
        const queryPath= parkingAreaTypeId ? `/api/v1/parkingareas?skip=${skip}&length=${length}&parkingAreaTypeId=${parkingAreaTypeId}` :`/api/v1/parkingareas?skip=${skip}&length=${length}`;
        return this.http.get<ApiResponse<ParkingArea[]>>(queryPath)
            .pipe(
                map((response: ApiResponse<ParkingArea[]>) => {
                    return response.data;
                }),
                catchError((error) => {
                    console.error('Error fetching parking areas', error);
                    return [];
                })
       )
    }
}