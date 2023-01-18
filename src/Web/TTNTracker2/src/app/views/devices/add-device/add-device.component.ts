import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { eventNames } from 'process';
import { DeviceCreateModel } from '../../../models/deviceCreateModel';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styles: [
  ]
})
export class AddDeviceComponent implements OnInit {

  availableDevices: MediaDeviceInfo[];
  deviceCurrent: MediaDeviceInfo;
  deviceSelected: string;
  hasPermission: boolean;
  hasDevices: boolean;
  displayCamera: boolean = false;
  isLoading = false;



  formModel: any;
  frequencies: any;
  lorawanVersions: any;
  constructor(private fb: FormBuilder,
    private service: DeviceService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.formModel = this.fb.group({
      deviceId: ['', [Validators.required]],
      deviceName: ['', [Validators.required]],
      deviceDescription: [''],
      appEui: ['', [Validators.required, Validators.minLength(23), Validators.maxLength(23)]],
      devEui: ['', [Validators.required, Validators.minLength(23), Validators.maxLength(23)]],
      lorawanVersion: ['', [Validators.required]],
      frequencyPlanId: ['', [Validators.required]],
      appKey: ['', [Validators.required, Validators.minLength(47), Validators.maxLength(47)]],
      networkServerAddress: ['eu1.cloud.thethings.network'],
      applicationServerAddress: ['eu1.cloud.thethings.network'],
      joinServerAddress: ['eu1.cloud.thethings.network'],
      supportsClassB: [false],
      supportsClassC: [false]
    });

    this.bindCombo();
    console.log(this.displayCamera)

  }

  onSubmit() {
    var device = new DeviceCreateModel();
    device.deviceId = this.formModel.value.deviceId.trim();
    device.deviceName = this.formModel.value.deviceName;
    device.appEui = this.removeSpaceInText(this.formModel.value.appEui);
    device.devEui = this.removeSpaceInText(this.formModel.value.devEui);
    device.deviceDescription = this.formModel.value.deviceDescription;
    device.lorawanVersion = this.formModel.value.lorawanVersion;
    device.applicationServerAddress = this.formModel.value.applicationServerAddress;
    device.networkServerAddress = this.formModel.value.networkServerAddress;
    device.joinServerAddress = this.formModel.value.joinServerAddress;
    device.appKey = this.removeSpaceInText(this.formModel.value.appKey);
    device.frequencyPlanId = this.formModel.value.frequencyPlanId;
    device.supportsClassB = this.formModel.value.supportsClassB;
    device.supportsClassC = this.formModel.value.supportsClassC;

    console.log(device)

    this.service.registerDevice(device).subscribe(
      (res: any) => {
        this.isLoading = false;
        if (res.status) {
          this.router.navigateByUrl("/devices/d?mid=" + device.deviceId)
        } else {
          console.log(res);
          this.toastr.error(res.message, 'Device Registeration Failed');
        }
      }
    );
  }

  bindCombo() {
    this.service.getFrequencyList().subscribe(result => {
      this.frequencies = result;
    })

    this.service.getLorawanVersionList().subscribe(result => {
      this.lorawanVersions = result;
    })
  }

  // allowNumericDigitsOnlyOnKeyUp(e) {
  //   console.log(e.target.value);

  //   if (/\D/g.test(e.target.value)) {
  //     alert('here')
  //     e.target.value = e.target.value.replace(/\D/g, '');
  //   }
  // }

  // // Only Integer Numbers
  // keyPressNumbers(event) {
  //   var charCode = (event.which) ? event.which : event.keyCode;
  //   // Only Numbers 0-9
  //   if ((charCode < 48 || charCode > 57)) {
  //     event.preventDefault();
  //     return false;
  //   } else {
  //     return true;
  //   }
  // }

  // Only AlphaNumeric
  keyPressAlphanumeric(event) {

    var inp = String.fromCharCode(event.keyCode);
    var charCode = (event.which) ? event.which : event.keyCode;
    // console.log(charCode)
    if (/[a-fA-F0-9]/.test(inp) || charCode == 8 || charCode == 86 || charCode == 67 || charCode == 88) {
      var len = event.target.value.length;
      // console.log(inp);

      return true;
    } else {
      event.preventDefault();
      return false;
    }
  }

  myFunction(event) {
    if (event.target.value.length > 0) {
      event.target.value = event.target.value.split(' ').join('')
      event.target.value = this.format2DigitSpace(event.target.value);
    }
  }

  removeSpaceInText(value) {
    if (value.length == 0) return value;
    return value.split(' ').join('')
  }

  format2DigitSpace(value: any) {
    return value.match(new RegExp('.{1,2}', 'g')).join(" ");// event.target.value.replace(/\d{4}(?=.)/g, ' ')
  }

  onCodeResult(resultString: string) {
    console.log(resultString);
    this.displayCamera = false;
    this.service.retrieveDeviceQrCodeDetails(resultString).subscribe(
      (res: any) => {
        console.log(res);

        this.formModel.patchValue({

          devEui: this.format2DigitSpace(res.devEui),
          appEui: this.format2DigitSpace(res.appEui),
          appKey: this.format2DigitSpace(res.appKey),
          lorawanVersion: res.lorawanVersion,
          supportsClassB: res.supportsClassB,
          supportsClassC: res.supportsClassC

        });
      }
    )
  }

  onHasPermission(has: boolean) {
    this.hasPermission = has;
  }

  onCamerasFound(devices: MediaDeviceInfo[]): void {
    this.availableDevices = devices;
    this.hasDevices = Boolean(devices && devices.length);
  }
  enableCamera() {
    // console.log(this.displayCamera)
    this.displayCamera = this.displayCamera == true ? false : true;
    //console.log(this.displayCamera)
  }
  toggleLoading() {
    this.isLoading = true;
  }
}
