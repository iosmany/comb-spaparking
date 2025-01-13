
import { Routes } from '@angular/router';
import { ParkingPermitsviewComponent } from './parkingpermitsview/parkingpermitsview.component';
import { ParkingpermitdetailComponent } from './parkingpermit-detail/parkingpermitdetail.component';

export const routes: Routes = [
    { path: '', component: ParkingPermitsviewComponent },
    { path: 'detail/:id', component: ParkingpermitdetailComponent },
];