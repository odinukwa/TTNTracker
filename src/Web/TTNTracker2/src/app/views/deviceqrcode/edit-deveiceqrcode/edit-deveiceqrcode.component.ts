import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxConfirmBoxService } from 'ngx-confirm-box';
import { environment } from '../../../../environments/environment.prod';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-edit-deveiceqrcode',
  templateUrl: './edit-deveiceqrcode.component.html',
  styles: [
  ]
})
export class EditDeveiceqrcodeComponent implements OnInit {
  private baseUrl = environment.baseUrl2;
  formModel: FormGroup;
  lorawanVersions: any;
  qrPath: any;
  isLoading = false;
  bgColor = 'rgba(0,0,0,0.5)'; // overlay background color
  confirmHeading = '';
  confirmContent = "Are you sure want to delete tsddshis?";
  confirmCanceltext = "Cancel";
  confirmOkaytext = "Okay";


  constructor(private fb: FormBuilder,
    private service: DeviceService,
    private router: Router,
    private route: ActivatedRoute,
    private confirmBox: NgxConfirmBoxService) {
    this.bindCombo();
    this.formModel = this.fb.group({
      appEui: [{ value: '', disabled: true }],
      devEui: [{ value: '', disabled: true }],
      lorawanVersion: [{ value: '', disabled: true }],
      appKey: [{ value: '', disabled: true }],
      supportsClassB: [{ value: false, disabled: true }],
      supportsClassC: [{ value: false, disabled: true }]
    });
    var mid = this.route.snapshot.queryParamMap.get('mid');
    this.updateForm(mid);
  }

  ngOnInit(): void {




  }

  updateForm(mid) {
    console.log(mid, 'usman');
    this.service.retrieveDeviceQrCodeDetails(mid).subscribe(
      (res: any) => {
        this.formModel.patchValue({
          appEui: res.appEui,
          devEui: res.devEui,
          lorawanVersion: res.lorawanVersion,
          appKey: res.appKey,
          supportsClassB: res.supportsClassB,
          supportsClassC: res.supportsClassC
        });

        this.qrPath = this.baseUrl + res.qrcodePath;

      }
    )


  }

  deleteRecord() {
    this.isLoading = true;
    this.confirmBox.show();
  }

  bindCombo() {

    this.service.getLorawanVersionList().subscribe(result => {
      this.lorawanVersions = result;
    })
  }



  confirmChange(showConfirm: boolean) {
    this.isLoading = true;
    if (showConfirm) {
      var devEui = this.formModel.get('devEui').value;
      this.service.deleteDeviceQrCode(devEui).subscribe(
        (res: any) => {

          if (res.status) {
            this.router.navigateByUrl('/devicesqr')
          } else {
            this.isLoading = false;
            alert(res.message)
          }
        }
      )
    } else {
      this.isLoading = false;
    }
  }
}
