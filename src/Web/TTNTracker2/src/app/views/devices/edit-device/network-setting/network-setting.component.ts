import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DeviceNsUpdateModel } from '../../../../models/deviceUpdateModel';
import { DeviceService } from '../../../../service/device.service';

@Component({
  selector: 'app-network-setting',
  templateUrl: './network-setting.component.html',
  styles: [
  ]
})
export class NetworkSettingComponent implements OnInit {
  formNModel: FormGroup;
  constructor(private service: DeviceService,
    private toastr: ToastrService,
    private fb: FormBuilder) {
    this.formNModel = this.fb.group({
      supportsClassB: [false],
      supportsClassC: [false],
      lorawanVersion: ['', [Validators.required]],
      frequencyPlanId: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
  }
  isCollapsed: boolean = true;
  isLoading: boolean = false;



  onSubmit() {

    console.log(this.formNModel.value)
    var device = new DeviceNsUpdateModel();
    device.deviceId = this.service.devModel.deviceId;
    device.appEui = this.service.devModel.appEui;
    device.devEui = this.service.devModel.devEui;
    device.frequencyPlanId = this.formNModel.value.frequencyPlanId;
    device.lorawanVersion = this.formNModel.value.lorawanVersion;
    this.isLoading = true;
    this.service.updateDeviceNs(device).subscribe(
      (res: any) => {
        this.isLoading = false;
        if (res.status) {
          this.toastr.success('Device Updated Successfully', 'Success')
        } else {
          console.log(res);
          this.toastr.error(res.message, 'Device Registeration Failed');
        }
      }
    )
  }
}
