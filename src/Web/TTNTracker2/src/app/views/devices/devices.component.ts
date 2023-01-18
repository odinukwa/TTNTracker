import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../../service/device.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddDeviceComponent } from './add-device/add-device.component';
import { NgxSpinnerService } from 'ngx-spinner';
import { DeviceModel } from '../../models/devicesModel';


@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styles: [
  ]
})
export class DevicesComponent implements OnInit {
  modalRef: BsModalRef;
  constructor(private service: DeviceService,
    private bsModalService: BsModalService,
    private spinner: NgxSpinnerService) { }
  list: DeviceModel[];
  ngOnInit(): void {
    this.spinner.show();
    this.service.refreshList().subscribe(
      (res: any) => {
        this.list = res as DeviceModel[];
        this.spinner.hide();
      }
    );
    // console.log(this.service.list);

    //this.spinner.show();

    // setTimeout(() => {
    //   /** spinner ends after 5 seconds */
    //   this.spinner.hide();
    // }, 20000);
  }
  addDevice() {
    this.modalRef = this.bsModalService.show(AddDeviceComponent, { class: 'modal-lg' });
  }
}
