import { Component, computed, inject, NgModule, OnInit, signal } from "@angular/core";
import { ParkingAreaService } from "../parkingarea.service";
import { ParkingArea, ParkingAreaType } from "../parking-area.models";
import { FormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { ParkingAreaTypeService } from "../parkingareatype.service";


@Component({
  selector: 'app-parkingareateable',
  templateUrl: './parkingareatable.component.html',
  imports:[
    FormsModule,
    CommonModule,
  ]
})
export class ParkingAreaTableComponent implements OnInit {

    title: string = 'Parking Areas';        
    parkingAreaService: ParkingAreaService= inject(ParkingAreaService);
    parkingAreaTypeService: ParkingAreaTypeService= inject(ParkingAreaTypeService);
    page:number = 0;
    length: number = 50;
    totalItems: number = 0;
    data: ParkingArea[] = [];
    parkingAreaTypes: ParkingAreaType[] = [];

    selectedParkingAreaType: number = 0;
    
    ngOnInit(): void {
        this.load();
        this.filter();
    }

    filter(){ 
        return this.parkingAreaService.getParkingAreas(this.page, this.length, this.selectedParkingAreaType)
            .subscribe((data: ParkingArea[]) => {
                this.data = data    
            });
    }

    onParkingAreaTypeChange(){
        this.filter();
    }

    load(){
        this.parkingAreaTypeService.getParkingAreaTypes()
            .subscribe((data: ParkingAreaType[]) => {
                this.parkingAreaTypes = data;
            });
    }
}