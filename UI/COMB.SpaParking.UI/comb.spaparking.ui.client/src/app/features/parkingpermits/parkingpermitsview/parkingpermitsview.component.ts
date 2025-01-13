import { Component } from '@angular/core';
import { ParkingPermitTableComponent } from '../components/parkingpermittable.component';

@Component({
  selector: 'app-parkingpermisview',
  templateUrl: './parkingpermitsview.component.html',
  styleUrl: './parkingpermitsview.component.css',
  imports:[ ParkingPermitTableComponent] 
})
export class ParkingPermitsviewComponent {

}
