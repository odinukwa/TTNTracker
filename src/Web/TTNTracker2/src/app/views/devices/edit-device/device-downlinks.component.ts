import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { DeviceDownlinkModel } from '../../../models/deviceDownlinkModel';
import { DeviceService } from '../../../service/device.service';

@Component({
  selector: 'app-device-downlinks',
  templateUrl: './device-downlinks.component.html',
  styles: [
  ]
})
export class DeviceDownlinksComponent implements OnInit {
  downlinkList: any;
  source: LocalDataSource
  constructor(
    private service: DeviceService,
    private route: ActivatedRoute) {
    var mid = this.route.snapshot.queryParamMap.get('mid');
    //alert(mid)
    this.service.refreshDownlink(mid).subscribe(
      (res: any) => {
        // console.log('am here with result')
        // console.log(res, 'am here with result2')
        //this.downlinkList = res;
        this.source = res;
        // console.log(this.downlinkList, 'am here with result3')

      }
    )
  }

  settings = {
    actions: false,
    hideHeader: false,
    hideSubHeader: false,
    columns: {
      deviceId: {
        title: 'Device ID'
      },
      deviceName: {
        title: 'Dev. Name'
      },
      devEui: {
        title: 'Dev. EUI'
      },
      appEui: {
        title: 'App. EUI'
      },
      latitude: {
        title: 'Longitude'
      },
      longitude: {
        title: 'Longitude'
      }
    }
  };
  ngOnInit(): void {

  }

}
