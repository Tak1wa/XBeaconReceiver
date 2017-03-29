using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBeaconReceiver.Models.Services
{
    public class iBeaconScannerService : BindableBase
    {
        public static iBeaconScannerService Instance { get; private set; } = new iBeaconScannerService();
        private iBeaconScannerService()
        {
            Plugin.BluetoothLE.CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
            {
                if(scanResult.AdvertisementData.ManufacturerData.IsiBeaconAdvertisingPacket())
                {
                    var iBeaconPacket = scanResult.AdvertisementData.ManufacturerData.ToiBeaconAdvertisingPacket();
                    var existPacket = ScanningPackets.FirstOrDefault(item =>
                    {
                        return item.Uuid == iBeaconPacket.Uuid &&
                               item.Major == iBeaconPacket.Major &&
                               item.Minor == iBeaconPacket.Minor;
                    });
                    if(existPacket == null)
                    {
                        iBeaconPacket.TxPower = scanResult.AdvertisementData.TxPower;
                        ScanningPackets.Add(iBeaconPacket);
                    }
                    else
                    {
                        existPacket.TxPower = scanResult.AdvertisementData.TxPower;
                        existPacket.LastScanDateTime = iBeaconPacket.LastScanDateTime;
                    }
                }
            });
        }
        
        public ObservableCollection<iBeaconAdvertisingPacket> ScanningPackets { get; set; } =
            new ObservableCollection<iBeaconAdvertisingPacket>();
    }
}
