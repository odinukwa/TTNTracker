import { Component, OnInit } from '@angular/core';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-device-settings',
  templateUrl: './device-settings.component.html',
  styles: [
  ]
})
export class DeviceSettingsComponent implements OnInit {

  constructor(private service: DeviceService) { }

  ngOnInit(): void {

  }

}
