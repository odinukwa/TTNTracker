import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DeviceQrcodeRoutingModule } from './deviceqrcode-routing.module';
import { DeviceqrcodeComponent } from './deviceqrcode.component';
import { AddDeveiceqrcodeComponent } from './add-deveiceqrcode/add-deveiceqrcode.component';
import { EditDeveiceqrcodeComponent } from './edit-deveiceqrcode/edit-deveiceqrcode.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxConfirmBoxModule, NgxConfirmBoxService } from 'ngx-confirm-box'


@NgModule({
  declarations: [
    DeviceqrcodeComponent,
    AddDeveiceqrcodeComponent,
    EditDeveiceqrcodeComponent,

  ],
  imports: [
    CommonModule,
    DeviceQrcodeRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    NgxConfirmBoxModule
  ],
  providers: [
    NgxConfirmBoxService
  ]
})
export class DeviceQrcodeModule { }
