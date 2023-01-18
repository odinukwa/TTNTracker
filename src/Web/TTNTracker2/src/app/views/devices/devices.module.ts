import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'


import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ModalModule } from 'ngx-bootstrap/modal';
// Tabs Component
import { TabsModule } from 'ngx-bootstrap/tabs';
import { DevicesRoutingModule } from './devices-routing.module';
import { AddDeviceComponent } from './add-device/add-device.component';
import { EditDeviceComponent } from './edit-device/edit-device.component';
import { DevicesComponent } from './devices.component';

import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { QrcodeComponent } from './qrcode/qrcode.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { DeviceMapComponent } from './edit-device/device-map.component';
import { DeviceViewComponent } from './edit-device/device-view.component';
import { DeviceDownlinksComponent } from './edit-device/device-downlinks.component';
import { DeviceSettingsComponent } from './edit-device/device-settings.component';
import { BasicSettingComponent } from './edit-device/basic-setting/basic-setting.component';
import { NetworkSettingComponent } from './edit-device/network-setting/network-setting.component';
import { JoinSettingComponent } from './edit-device/join-setting/join-setting.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';


@NgModule({
  declarations: [
    DevicesComponent,
    AddDeviceComponent,
    EditDeviceComponent,
    QrcodeComponent,
    DeviceMapComponent,
    DeviceViewComponent,
    DeviceDownlinksComponent,
    DeviceSettingsComponent,
    BasicSettingComponent,
    NetworkSettingComponent,
    JoinSettingComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    DevicesRoutingModule,
    CollapseModule.forRoot(),
    ModalModule.forRoot(),
    TabsModule,
    ZXingScannerModule,
    NgxSpinnerModule,
    Ng2SmartTableModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  entryComponents: [
    AddDeviceComponent,
    EditDeviceComponent
  ]
})
export class DevicesModule { }
