using Estimotes;
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
            EstimoteManager.Instance.Initialize().ContinueWith(x =>
            {
                System.Diagnostics.Debug.WriteLine($"Beacon Init Status: {x.Result}");
                if (x.Result != BeaconInitStatus.Success)
                    return;

                EstimoteManager.Instance.RegionStatusChanged += (sender, beaconArgs) =>
                {
                    return;
                };
                EstimoteManager.Instance.Ranged += (sender, beacons) =>
                {
                    if (beacons == null)
                        return;
                    
                    foreach(var beacon in beacons)
                    {
                        var packet = new iBeaconAdvertisingPacket
                        {
                            Uuid = beacon.Uuid,
                            Major = beacon.Major,
                            Minor = beacon.Minor,
                        };
                        var existPacket = ScanningPackets.FirstOrDefault(item =>
                        {
                            return item.Uuid == packet.Uuid &&
                                    item.Major == packet.Major &&
                                    item.Minor == packet.Minor;
                        });
                        if(existPacket == null)
                        {
                            ScanningPackets.Add(packet);
                        }
                    }
                };

                EstimoteManager.Instance.StopAllMonitoring();
                EstimoteManager.Instance.StopAllRanging();

                //Sample UUID.
                var region = new BeaconRegion("hogeIdentifier", "c58925a9-d178-44a9-8e5e-b717e6ede88b");
                EstimoteManager.Instance.StartMonitoring(region);
                EstimoteManager.Instance.StartRanging(region);
            });
        }
        
        public ObservableCollection<iBeaconAdvertisingPacket> ScanningPackets { get; set; } =
            new ObservableCollection<iBeaconAdvertisingPacket>();
    }
}
