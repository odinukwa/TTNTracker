import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import * as L from 'leaflet';
import 'leaflet-realtime';
import { DeviceModel } from '../../../models/devicesModel';
import { DeviceService } from '../../../service/device.service';
const iconRetinaUrl = 'assets/marker-icon-2x.png';
const iconUrl = 'assets/marker-icon.png';
const shadowUrl = 'assets/marker-shadow.png';
const iconDefault = L.icon({
  iconRetinaUrl,
  iconUrl,
  shadowUrl,
  iconSize: [25, 41],
  iconAnchor: [12, 41],
  popupAnchor: [1, -34],
  tooltipAnchor: [16, -28],
  shadowSize: [41, 41]
});
L.Marker.prototype.options.icon = iconDefault;
@Component({
  selector: 'app-edit-device',
  templateUrl: './edit-device.component.html',
  styles: [
  ]
})
export class EditDeviceComponent implements OnInit, AfterViewInit {

  map: any;
  realtime: any;

  constructor(private service: DeviceService,
    private route: ActivatedRoute) {
    var mid = this.route.snapshot.queryParamMap.get('mid');

    this.service.getSingleDevice(mid).subscribe(
      (res: any) => {

        console.log(res, 'usman')
        Object.assign(service.devModel2, res);
        console.log(service.devModel2, 'usman')

      }
    )
  }

  ngOnInit(): void {

  }
  ngAfterViewInit(): void {
    this.initRealTimeMap();

    //this.initMap();
  }

  private initMap(): void {
    this.map = L.map('map', {
      center: [6.5516, 3.2936],
      zoom: 13
    });

    const tiles = L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
      maxZoom: 18,
      attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, ' +
        'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      id: 'mapbox/streets-v11',
      tileSize: 512,
      zoomOffset: -1
    }).addTo(this.map);

    tiles.addTo(this.map);
  }

  initRealTimeMap() {
    this.map = L.map('map');
    // Start fetching realtime data
    this.realtime = L.realtime({
      url: 'https://wanderdrone.appspot.com/',
      crossOrigin: true,
      type: 'json'
    }, {
      interval: 3 * 1000
    }).addTo(this.map);

    var map = this.map;
    var realtime = this.realtime;

    this.realtime.on('update', function () {
      map.fitBounds(realtime.getBounds(), { maxZoom: 3 });
    });

    // Map layout
    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
      maxZoom: 18,
      attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, ' +
        'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
      id: 'mapbox/streets-v11',
      tileSize: 512,
      zoomOffset: -1
    }).addTo(this.map);
  }
}
