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

  root = 'http://localhost:5265/api';

  getDevices(): Observable<Device[]>
  {
    return this.http.get<Device[]>(this.root+'/Device/devices');
  }

  getUsers(): Observable<User[]>
  {
    return this.http.get<User[]>(this.root+'/User/users');
  }

  updateDevice(device: Device): Observable<Device>
  {
    return this.http.put<Device>(`${this.root+'/Device'}/${device.id}`, device);
  }

  createDevice(device: Device): Observable<Device>
  {
    return this.http.post<Device>(this.root+'/Device', device);
  }

  deleteDevice(id: number): Observable<any>
  {
    return this.http.delete(`${this.root+'/Device'}/${id}`);
  }

  register(user: any): Observable<any> {
    return this.http.post(`${this.root}/User`, user);
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.root}/User/login`, credentials);
  }

  assignDevice(deviceId: number, userId: number): Observable<any> {
    return this.http.post(`${this.root}/Device/${deviceId}/assign/${userId}`, {});
  }

  unassignDevice(deviceId: number, userId: number): Observable<any> {
    return this.http.post(`${this.root}/Device/${deviceId}/unassign/${userId}`, {});
  }
}
