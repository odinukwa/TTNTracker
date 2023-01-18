import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-device-view',
  templateUrl: './device-view.component.html',
  styles: [
  ]
})
export class DeviceViewComponent implements OnInit {

  constructor(private service: DeviceService) { }

  ngOnInit(): void {
    console.log('usman')
    console.log(this.service.devModel2, 'Usman')
    console.log('usman')
  }

}
