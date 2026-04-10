import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Device } from './device';
import {User} from './user';

@Injectable({
  providedIn: "root"
})

export class DeviceService
{
  constructor(private http: HttpClient) {}

  getDevices(): Observable<Device[]>
  {
    return this.http.get<Device[]>('http://localhost:5265/api/Device/devices');
  }

  getUsers(): Observable<User[]>
  {
    return this.http.get<User[]>('http://localhost:5265/api/User/users');
  }

  updateDevice(device: Device): Observable<Device>
  {
    return this.http.put<Device>(`${'http://localhost:5265/api/Device'}/${device.id}`, device);
  }

  createDevice(device: Device): Observable<Device>
  {
    return this.http.post<Device>('http://localhost:5265/api/Device', device);
  }

  deleteDevice(id: number): Observable<any>
  {
    return this.http.delete(`${'http://localhost:5265/api/Device'}/${id}`);
  }
}
