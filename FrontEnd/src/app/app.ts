import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeviceService } from './device.service';
import { FormsModule } from '@angular/forms';
import { Device } from './device';

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


  constructor(private deviceService: DeviceService, private cdr: ChangeDetectorRef) {
  }

  ngOnInit(): void {
    this.deviceService.getUsers().subscribe({
      next: (userData) => {
        this.users = [...userData];
        this.loadDevices();
      },
      error: (err) => console.error(err)
    });
  }

  private loadDevices() {
    this.deviceService.getDevices().subscribe({
      next: (data) => {
        this.devices = [...data];
        this.cdr.detectChanges();
      },
      error: (err) => console.error(err)
    });
  }
    getUserName(userID: number): string {
      console.log('Searching for:', userID, 'Inside:', this.users);
      if (!this.users || this.users.length === 0) return 'Loading...';

      const user = this.users.find(u => u.id === userID);

      return user ? user.name : 'Unknown User';
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
      userID: this.users[0]?.id || 0
    };
  }

  saveDevice()
  {
    const d = this.selectedDevice;
    if (!d) return;

    console.log('Data to be saved:', d);

    //validation - all fields should have values
    if(!d.name || !d.manufacturer || !d.operatingSystem || !d.osVersion || !d.processor || d.ramAmount <= 0 || !d.description || d.userID <= 0)
    {
      alert("Please fill in all fields with valid values!");
      return;
    }

    //validation - checking if item already exists by name
    const exists = this.devices.some(dev => dev.name.toLowerCase() === d.name.toLowerCase() && dev.id !== d.id);
    if (exists) {
      alert("A device with this name already exists!");
      return;
    }

    if (d.id > 0)
    {
      this.deviceService.updateDevice(d).subscribe({
        next: () => {
          alert("Update Successful!");
          this.loadDevices();
          this.selectedDevice = null;
        }
      });
    }
    else
    {
      this.deviceService.createDevice(d).subscribe({
        next: (newDevice) => {
          this.devices.push(newDevice);
          this.loadDevices();
          this.selectedDevice = null;
          this.cdr.detectChanges();
        },
        error: (err) => console.error('Save failed:', err)
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
}

