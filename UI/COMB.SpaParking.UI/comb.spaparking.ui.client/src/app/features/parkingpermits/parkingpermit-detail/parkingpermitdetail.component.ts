import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParkingPermitService } from '../parkingpermit.service';
import { ParkingPermit } from '../parking-permits.models';
import { NgIf } from '@angular/common';
import { ApiResponse } from '../../../api/api.models';

@Component({
  selector: 'app-parkingpermitdetail',
  templateUrl: './parkingpermitdetail.component.html',
  styleUrl: './parkingpermitdetail.component.css',
  imports: [ NgIf ]
})
export class ParkingpermitdetailComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: ParkingPermitService) { }

  model: ParkingPermit | null = null;
  expired: boolean = false;

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    console.log(this.route.snapshot.params);
    this.service.getParkingPermitById(id)
      .subscribe((permit: ParkingPermit | null) => {
        if (permit){
          this.model = permit;
          this.expired = new Date(this.model.expirationDate) < new Date();
        }
      });
  }

  deactivate(): void {
    const proceed= confirm('Are you sure you want to deactivate this permit?');
    if (this.model && proceed){
      this.service.deactivateParkingPermit(this.model.id)
        .subscribe((response) => {
            this.model!.inactive = false;
        });
    }
  }
 
}
