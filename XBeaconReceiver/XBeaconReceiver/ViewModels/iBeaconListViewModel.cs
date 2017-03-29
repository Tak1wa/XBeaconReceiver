using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBeaconReceiver.Models.Services;

namespace XBeaconReceiver.ViewModels
{
    public class iBeaconListViewModel
    {
        public ReadOnlyReactiveCollection<iBeaconAdvertisingPacketViewModel> BeaconPackets { get; set; }

        private iBeaconScannerService Service { get; set; } = iBeaconScannerService.Instance;

        public iBeaconListViewModel()
        {
            BeaconPackets = Service.ScanningPackets.ToReadOnlyReactiveCollection(p => new iBeaconAdvertisingPacketViewModel(p));
        }
    }
}
