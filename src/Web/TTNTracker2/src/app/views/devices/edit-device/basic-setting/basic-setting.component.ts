import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DeviceUpdateModel } from '../../../../models/deviceUpdateModel';
import { DeviceService } from '../../../../service/device.service';

@Component({
  selector: 'app-basic-setting',
  templateUrl: './basic-setting.component.html',
  styles: [
  ]
})
export class BasicSettingComponent implements OnInit {
  formBModel: FormGroup;
  constructor(private service: DeviceService,
    private toastr: ToastrService,
    private fb: FormBuilder) {
    console.log(this.service.devModel2, 'basic')
    this.formBModel = this.fb.group({
      deviceId: [{ value: '', disabled: true }],
      deviceName: [''],
      deviceDescription: [''],
      appEui: [{ value: '', disabled: true }],
      devEui: [{ value: '', disabled: true }],
      networkServerAddress: [{ value: '' }],
      applicationServerAddress: [''],
      joinServerAddress: ['']
    });


  }

  ngOnInit(): void {
    this.updateForm(this.service.devModel2);
  }
  isCollapsed: boolean = false;
  isLoading: boolean = false;


  onSubmit() {
    console.log(this.formBModel.value)
    var device = new DeviceUpdateModel();
    device.deviceId = this.formBModel.value.deviceId.trim();
    device.deviceName = this.formBModel.value.deviceName;
    device.appEui = this.removeSpaceInText(this.formBModel.value.appEui);
    device.devEui = this.removeSpaceInText(this.formBModel.value.devEui);
    device.deviceDescription = this.formBModel.value.deviceDescription;
    device.applicationServerAddress = this.formBModel.value.applicationServerAddress;
    device.networkServerAddress = this.formBModel.value.networkServerAddress;
    device.joinServerAddress = this.formBModel.value.joinServerAddress;

    this.service.updateDevice(device).subscribe(
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

  removeSpaceInText(value) {
    if (value.length == 0) return value;
    return value.split(' ').join('')
  }

  updateForm(model: any) {
    console.log(model);
    console.log(model.devEui, 'devEui')
    this.formBModel.patchValue({
      appEui: model.appEui,
      devEui: model.devEui,
      lorawanVersion: model.lorawanVersion,
      appKey: model.appKey,
      supportsClassB: model.supportsClassB,
      supportsClassC: model.supportsClassC
    });




  }
}
