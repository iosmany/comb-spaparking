import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: 'parking-areas', loadComponent: () => import('./features/parkingareas/parkingareasview/parkingareasview.component').then(m => m.ParkingareasviewComponent) },
  { path: 'parking-permits', loadChildren: () => import('./features/parkingpermits/parkingpermits.routes').then(m => m.routes) },
  { path: '', redirectTo: 'parking-areas', pathMatch: 'full' },
];
