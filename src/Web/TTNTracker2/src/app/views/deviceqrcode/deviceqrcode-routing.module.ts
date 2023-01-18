import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDeveiceqrcodeComponent } from './add-deveiceqrcode/add-deveiceqrcode.component';
import { DeviceqrcodeComponent } from './deviceqrcode.component';
import { EditDeveiceqrcodeComponent } from './edit-deveiceqrcode/edit-deveiceqrcode.component';

const routes: Routes = [
  {
    path: '',
    component: DeviceqrcodeComponent,
    data: {
      title: 'Devices Qr Code'
    }
  }
  ,
  {
    path: 'add',
    component: AddDeveiceqrcodeComponent,
    data: {
      title: 'Add Device QR Code'
    }
  },
  {
    path: 'd',
    component: EditDeveiceqrcodeComponent,
    data: {
      title: 'Edit Device QR Code'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DeviceQrcodeRoutingModule { }
