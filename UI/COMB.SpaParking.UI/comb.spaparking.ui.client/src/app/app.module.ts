import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ParkingpermitdetailComponent } from './features/parkingpermits/parkingpermit-detail/parkingpermitdetail/parkingpermitdetail.component';
import { ParkingareasviewComponent } from './features/parkingares/parkingareasview/parkingareasview.component';
import { ParkingpermisviewComponent } from './pages/parkingpermits/parkingpermisview/parkingpermitsview.component';
import { HeaderComponent } from './layout/components/header/header.component';
import { SidebarComponent } from './layout/components/sidebar/sidebar.component';
import { FooterComponent } from './layout/components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    ParkingpermitdetailComponent,
    ParkingareasviewComponent,
    ParkingpermisviewComponent,
    HeaderComponent,
    SidebarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
