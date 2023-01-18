import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DeviceCreateModel } from '../../../models/deviceCreateModel';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-add-deveiceqrcode',
  templateUrl: './add-deveiceqrcode.component.html',
  styles: [
  ]
})
export class AddDeveiceqrcodeComponent implements OnInit {
  isLoading = false;



  formModel: any;
  lorawanVersions: any;
  constructor(private fb: FormBuilder,
    private service: DeviceService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.formModel = this.fb.group({
      appEui: ['', [Validators.required, Validators.minLength(23), Validators.maxLength(23)]],
      devEui: ['', [Validators.required, Validators.minLength(23), Validators.maxLength(23)]],
      lorawanVersion: ['', [Validators.required]],
      appKey: ['', [Validators.required, Validators.minLength(47), Validators.maxLength(47)]],
      supportsClassB: [false],
      supportsClassC: [false]
    });

    this.bindCombo();

  }

  onSubmit() {
    var device = new DeviceCreateModel();
    device.appEui = this.removeSpaceInText(this.formModel.value.appEui);
    device.devEui = this.removeSpaceInText(this.formModel.value.devEui);
    device.lorawanVersion = this.formModel.value.lorawanVersion;
    device.appKey = this.removeSpaceInText(this.formModel.value.appKey);
    device.supportsClassB = this.formModel.value.supportsClassB;
    device.supportsClassC = this.formModel.value.supportsClassC;

    console.log(device)
    this.isLoading = true;
    this.service.generateDeviceQrCode(device).subscribe(
      (res: any) => {
        this.isLoading = false;
        if (res.status) {
          this.router.navigateByUrl("/devicesqr/d?mid=" + device.devEui)
        } else {
          console.log(res);
          this.toastr.error(res.message, 'Device QrCode Generation Failed');
        }
      }
    );
  }

  bindCombo() {

    this.service.getLorawanVersionList().subscribe(result => {
      this.lorawanVersions = result;
    })
  }


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



  toggleLoading() {
    this.isLoading = true;
  }
}
