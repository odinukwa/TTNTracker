import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DeviceJsUpdateModel } from '../../../../models/deviceUpdateModel';
import { DeviceService } from '../../../../service/device.service';

@Component({
  selector: 'app-join-setting',
  templateUrl: './join-setting.component.html',
  styles: [
  ]
})
export class JoinSettingComponent implements OnInit {
  formNModel: FormGroup;
  constructor(private service: DeviceService,
    private toastr: ToastrService,
    private fb: FormBuilder) {
    this.formNModel = this.fb.group({
      appKey: ['', [Validators.required, Validators.minLength(47), Validators.maxLength(47)]],
    });
  }

  ngOnInit(): void {
  }

  isCollapsed: boolean = true;

  isLoading: boolean = false;



  onSubmit() {

    console.log(this.formNModel.value)
    var device = new DeviceJsUpdateModel();
    device.deviceId = this.service.devModel.deviceId;
    device.appEui = this.service.devModel.appEui;
    device.devEui = this.service.devModel.devEui;
    device.appKey = this.formNModel.value.appKey;

    this.isLoading = true;
    this.service.updateDeviceJs(device).subscribe(
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
