export enum DeviceType
{
  Phone = 0,
  Tablet = 1
}

export interface Device
{
  id: number;
  name: string;
  manufacturer: string;
  type: DeviceType;
  operatingSystem: string;
  osVersion: string;
  processor: string;
  ramAmount: number;
  description: string;
  userID: number | null;
}
