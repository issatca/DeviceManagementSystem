import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeviceService } from './device.service';
import { FormsModule } from '@angular/forms';
import { Device } from './device';
import {User} from './user';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  devices: any[] = [];
  users: any[] = [];
  currentUser: User | null = null;

  showLogin = true;
  isRegistering = false;
  loginData = { email: '', password: '' };
  registerData = { name: '', mail: '', password: '', role: 'User', location: '' };

  constructor(private deviceService: DeviceService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    const savedUser = localStorage.getItem('user');
    if (savedUser) {
      this.currentUser = JSON.parse(savedUser);
      this.showLogin = false;
      this.loadInitialData();
    }
  }

  loadInitialData() {
    this.deviceService.getUsers().subscribe({
      next: (userData) => {
        this.users = userData;
        console.log('Users loaded:', this.users.length);
        this.loadDevices();
      },
      error: (err) => {
        console.error('Failed to load users, loading devices anyway:', err);
        this.loadDevices();
      }
    });
  }

  onLogin() {
    this.deviceService.login({ email: this.loginData.email, password: this.loginData.password }).subscribe({
      next: (user) => {
        this.currentUser = user;
        localStorage.setItem('user', JSON.stringify(user));
        this.showLogin = false;
        this.loadInitialData();
      },
      error: () => alert("Invalid Credentials")
    });
  }

  onRegister() {
    const d = this.registerData;
    if (!d.name || !d.mail || !d.password || !d.location) {
      alert("All fields are required for registration!");
      return;
    }

    this.deviceService.register(d).subscribe({
      next: () => {
        alert("Registration successful!");
        this.isRegistering = false;
        this.registerData = { name: '', mail: '', password: '', role: 'User', location: '' };
      },
      error: (err) => alert("Registration failed: " + err.error)
    });
  }

  logout() {
    this.currentUser = null;
    localStorage.removeItem('user');
    this.showLogin = true;
  }

  private loadDevices() {
    this.deviceService.getDevices().subscribe({
      next: (data) => {
        this.devices = data.map(device => {
          let typeValue: any = device.type;

          if (typeValue === 'Phone') typeValue = 0;
          else if (typeValue === 'Tablet') typeValue = 1;

          return {
            ...device,
            type: Number(typeValue)
          };
        });
        this.cdr.detectChanges();
      },
      error: (err) => console.error(err)
    });
  }
  getUserName(userID: any): string {
    if (userID === null || userID === undefined || userID === 0) {
      return 'No user';
    }

    const user = this.users.find(u => String(u.id) === String(userID));

    if (user) {
      return user.name;
    }

    return `ID: ${userID} (Not Found)`;
  }

    selectedDevice: any = null;

  viewDetails(device: any)
  {
    this.isEditMode = false;
    this.selectedDevice = { ...device };
  }

  createNew()
  {
    this.isEditMode = true;
    this.selectedDevice = {
      id: 0,
      name: '',
      manufacturer: '',
      type: 0,
      operatingSystem: '',
      osVersion: '',
      processor: '',
      ramAmount: 0,
      description: '',
      userID: null
    };
  }

  saveDevice() {
    const d = this.selectedDevice;
    if (!d) return;

    if (d.id > 0) {
      this.deviceService.updateDevice(d).subscribe({
        next: (updatedDevice) => {
          const index = this.devices.findIndex(dev => dev.id === d.id);
          if (index !== -1) {
            this.devices[index] = { ...updatedDevice };
          }
          this.selectedDevice = null;
          this.cdr.detectChanges();
        }
      });
    } else {
      this.deviceService.createDevice(d).subscribe({
        next: (newDevice) => {
          this.devices = [...this.devices, newDevice];
          this.selectedDevice = null;
          this.cdr.detectChanges();
        }
      });
    }
  }

  isEditMode: boolean = false;

  editDevice(device: any) {
    this.isEditMode = true;
    this.selectedDevice = { ...device };
  }


  deleteDevice(id: number)
  {
    if (confirm('Delete this device?'))
    {
      this.deviceService.deleteDevice(id).subscribe({
        next: () => {
          this.devices = this.devices.filter(d => d.id !== id);
          this.cdr.detectChanges();
        }
      });
    }
  }

  assignToMe(deviceId: number) {
    if (!this.currentUser) return;

    this.deviceService.assignDevice(deviceId, this.currentUser.id).subscribe({
      next: () => {
        this.loadDevices();

        const index = this.devices.findIndex(d => d.id === deviceId);
        if (index !== -1) {
          this.devices[index].userID = this.currentUser!.id;
        }
        this.cdr.detectChanges();
      },
      error: (err) => console.error(err)
    });
  }

  unassignFromMe(deviceId: number) {
    if (!this.currentUser) return;

    this.deviceService.unassignDevice(deviceId, this.currentUser.id).subscribe({
      next: () => {
        this.loadDevices()
      },
      error: (err) => console.error(err)
    });
  }
}

