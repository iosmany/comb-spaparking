import { Component, computed, inject, NgModule, OnInit, signal } from "@angular/core";
import { ParkingPermitService } from "../parkingpermit.service";
import { ParkingPermit } from "../parking-permits.models";
import { FormsModule, NgModel } from "@angular/forms";
import { CommonModule, NgFor, NgForOf } from "@angular/common";
import { RouterLink } from "@angular/router";


@Component({
  selector: 'app-parkingpermitteable',
  templateUrl: './parkingpermittable.component.html',
  imports:[
    FormsModule,
    CommonModule,
    RouterLink,
  ]
})
export class ParkingPermitTableComponent implements OnInit {

    title: string = 'Parking Permits';        
    parkingService: ParkingPermitService= inject(ParkingPermitService);

    page: number = 0;
    length: number = 8;
    totalItems: number = 0;
    data: ParkingPermit[] = [];

    byLicensePlate: string = '';
    selectedExpiredStatus: boolean | undefined = false;   //in order to show active permits by default
    
    noMoreResults: boolean = false;

    ngOnInit(): void {
        this.filter();
    }

    filter() {
        return this.parkingService.getParkingPermits(this.page, this.length, this.byLicensePlate, this.selectedExpiredStatus)
            .subscribe((data: ParkingPermit[]) => {
                this.data = data;
                this.noMoreResults = data.length < this.length;
            });
    }

    onLicensePlateChange() {
        this.filter();
    }

    onExpiredStatusChange(){
        this.filter();
    }

    onNext(){
        if(this.noMoreResults)return;
        this.page++;
        this.filter();
    }

    onPrevious(){
        if(this.page > 0){
            this.page--;
        }
        this.filter();
    }
}