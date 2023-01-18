export class DeviceUpdateModel {
    public deviceId: string;
    public devEui: string;
    public appEui: string;
    public deviceName: string;
    public deviceDescription: string;
    public applicationServerAddress: string;
    public networkServerAddress: string;
    public joinServerAddress: string;
}

export class DeviceNsUpdateModel {
    public deviceId: string;
    public devEui: string;
    public appEui: string;
    public lorawanVersion: string;
    public frequencyPlanId: string;
}

export class DeviceJsUpdateModel {
    public deviceId: string;
    public devEui: string;
    public appEui: string;
    public appKey: string;
}