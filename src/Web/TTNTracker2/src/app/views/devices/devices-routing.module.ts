import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDeviceComponent } from './add-device/add-device.component';
import { DevicesComponent } from './devices.component';
import { EditDeviceComponent } from './edit-device/edit-device.component';

const routes: Routes = [
  {
    path: '',
    component: DevicesComponent,
    data: {
      title: 'Devices'
    }
  }
  ,
  {
    path: 'add',
    component: AddDeviceComponent,
    data: {
      title: 'Add Device'
    }
  },
  {
    path: 'd',
    component: EditDeviceComponent,
    data: {
      title: 'Edit Device'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DevicesRoutingModule { }
