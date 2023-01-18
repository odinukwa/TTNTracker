import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { map, catchError } from 'rxjs/operators';
import { DeviceModel } from '../models/devicesModel';
import { Observable } from "rxjs";
import { DeviceCreateModel } from '../models/deviceCreateModel';
import { DeviceDownlinkModel } from '../models/deviceDownlinkModel';
import { DeviceJsUpdateModel, DeviceNsUpdateModel, DeviceUpdateModel } from '../models/deviceUpdateModel';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {
  private baseUrl = environment.baseUrl;
  private httpOptions: any;
  errorContent: any;
  devModel: DeviceModel = new DeviceModel();
  devModel2: DeviceCreateModel = new DeviceCreateModel();

  constructor(private http: HttpClient) {
  }

  public handleError(error: any) {
    console.log(error);
    this.errorContent = 'Check your Internet Connection and Try again.';
    if (error.status == 0) {
      alert(this.errorContent);

    }
    else if (error.status == 400) {
      alert(this.errorContent);
    }
    else if (error.status == 501) {
      alert("Request failed.Try again");
    }
    else {
      // alert("Proccess error. Try again");
    }
    return Observable.throw(error.message ? error.message : error.name || 'Server error');
  }
  list: DeviceModel[];
  listQr: DeviceModel[];

  refreshList() {
    return this.http.get(`${this.baseUrl}/device`);
  }

  refreshDownlink(devId: string) {
    console.log('am here 2')
    return this.http.get(`${this.baseUrl}/device/downlink/${devId}`)
      .pipe(map(res => {
        //console.log('am here 2')
        return res;
      }),
        catchError(this.handleError)
      );;
  }

  refreshQRList() {
    return this.http.get(`${this.baseUrl}/device/qrcodes`)
      .toPromise()
      .then(res => this.listQr = res as DeviceModel[]);
  }

  getFrequencyList() {
    return this.http.get(`${this.baseUrl}/frequency`)
      .pipe(map(res => {
        //console.log(res);

        return res;
      }),
        catchError(this.handleError)
      );

  }
  getLorawanVersionList() {
    return this.http.get(`${this.baseUrl}/lorawanVersion`)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  registerDevice(model: DeviceCreateModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(`${this.baseUrl}/device`, JSON.stringify(model), this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  updateDevice(model: DeviceUpdateModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.put(`${this.baseUrl}/device/${model.deviceId}`, JSON.stringify(model), this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  updateDeviceNs(model: DeviceNsUpdateModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.put(`${this.baseUrl}/device/ns/${model.deviceId}`, JSON.stringify(model), this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  updateDeviceJs(model: DeviceJsUpdateModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.put(`${this.baseUrl}/device/js/${model.deviceId}`, JSON.stringify(model), this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  getSingleDevice(devId: string) {

    return this.http.get(`${this.baseUrl}/device/${devId}`)
      .pipe(map(res => {

        return res;
      }),
        catchError(this.handleError)
      );

  }

  generateDeviceQrCode(model: DeviceCreateModel) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.post(`${this.baseUrl}/device/generateqrcode`, JSON.stringify(model), this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  retrieveDeviceQrCodeDetails(devEui: string) {

    return this.http.get(`${this.baseUrl}/device/readqrcode?devEui=${devEui}`)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }

  deleteDeviceQrCode(devEui: string) {
    this.httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.delete(`${this.baseUrl}/device/deleteqrcode/${devEui}`, this.httpOptions)
      .pipe(map(res => {
        //console.log(res);
        return res;
      }),
        catchError(this.handleError)
      );

  }
}
