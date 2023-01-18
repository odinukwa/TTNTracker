import { Component, OnInit } from '@angular/core';
import { NgxConfirmBoxService } from 'ngx-confirm-box';
import { DeviceService } from '../../service/device.service';

@Component({
  selector: 'app-deviceqrcode',
  templateUrl: './deviceqrcode.component.html',
  styles: [
  ]
})
export class DeviceqrcodeComponent implements OnInit {
  devEui: string;
  bgColor = 'rgba(0,0,0,0.5)'; // overlay background color
  confirmHeading = '';
  confirmContent = "Are you sure want to delete tsddshis?";
  confirmCanceltext = "Cancel";
  confirmOkaytext = "Okay";
  constructor(private service: DeviceService, private confirmBox: NgxConfirmBoxService) { }

  ngOnInit(): void {
    this.refreshList();
  }

  deleteRecord(devEui: string) {
    this.devEui = devEui;
    this.confirmBox.show();
  }

  confirmChange(showConfirm: boolean) {
    if (showConfirm) {
      this.service.deleteDeviceQrCode(this.devEui).subscribe(
        (res: any) => {
          if (res.status) {
            this.refreshList();
          } else {
            alert(res.message)
          }
        }
      )
    } else {
    }
  }

  refreshList() {
    this.service.refreshQRList();
  }
}
