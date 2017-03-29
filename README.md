# XBeaconReceiver

[![Build status](https://ci.appveyor.com/api/projects/status/lq4n9c5wfu230t11?svg=true)](https://ci.appveyor.com/project/Tak1wa/xbeaconreceiver)

iBeacon Receiver For Xamarin.Forms.  
using Plugin : [ACR Bluetooth LE Reactive Plugin for Xamarin](https://www.nuget.org/packages/Acr.Ble/)

### Sample Flow
1. Boot Application.
2. Scan Advertising.
3. Launch Detail Page.

### Platform
- Android 4.4+
- iOS 7+

### Analyze iBeacon Advertise Packet Structure
- UUID
- Major
- Minor
- Power etc...

Since iOS can not acquire advertisement packets unless you use the CoreLocation API, you can not get advertisement packets in this repository.
