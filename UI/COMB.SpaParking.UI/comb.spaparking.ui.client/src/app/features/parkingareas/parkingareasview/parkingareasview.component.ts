import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { ParkingAreaTableComponent } from '../components/parkingareatable.component';

@Component({
  selector: 'app-parkingareasview',
  templateUrl: './parkingareasview.component.html',
  styleUrl: './parkingareasview.component.css',
  imports: [ ParkingAreaTableComponent ] 
})
export class ParkingareasviewComponent {

}
