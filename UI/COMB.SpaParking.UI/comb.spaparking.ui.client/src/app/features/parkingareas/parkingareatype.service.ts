import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map } from "rxjs";
import { ApiResponse } from "../../api/api.models";
import { ParkingArea, ParkingAreaType } from "./parking-area.models";

export interface FilterParkingAreas {
    getParkingAreas(page: number, length: number): any;
}

@Injectable({
    providedIn: 'root'
})
export class ParkingAreaTypeService {

    constructor(private http: HttpClient) {
    }

    getParkingAreaTypes() {
        return this.http.get<ApiResponse<ParkingAreaType[]>>(`/api/v1/parkingareatypes`)
            .pipe(
                map((response: ApiResponse<ParkingAreaType[]>) => {
                    return response.data;
                }),
                catchError((error) => {
                    console.error('Error fetching parking areas', error);
                    return [];
                })
       )
    }
}