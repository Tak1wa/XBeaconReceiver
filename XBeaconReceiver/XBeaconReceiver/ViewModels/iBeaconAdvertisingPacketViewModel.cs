using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBeaconReceiver.Models;

namespace XBeaconReceiver.ViewModels
{
    public class iBeaconAdvertisingPacketViewModel
    {
        public ReadOnlyReactiveProperty<int> CompanyId { get; set; }

        public ReadOnlyReactiveProperty<string> Uuid { get; set; }

        public ReadOnlyReactiveProperty<int> Major { get; set; }

        public ReadOnlyReactiveProperty<int> Minor { get; set; }

        public ReadOnlyReactiveProperty<int> SignalPower { get; set; }

        public ReadOnlyReactiveProperty<int> TxPower { get; set; }

        public iBeaconAdvertisingPacketViewModel(iBeaconAdvertisingPacket model)
        {
            CompanyId = model.ObserveProperty(m => m.CompanyId).ToReadOnlyReactiveProperty();
            Uuid = model.ObserveProperty(m => m.Uuid).ToReadOnlyReactiveProperty();
            Major = model.ObserveProperty(m => m.Major).ToReadOnlyReactiveProperty();
            Minor = model.ObserveProperty(m => m.Minor).ToReadOnlyReactiveProperty();
            SignalPower = model.ObserveProperty(m => m.SignalPower).ToReadOnlyReactiveProperty();
            TxPower = model.ObserveProperty(m => m.TxPower).ToReadOnlyReactiveProperty();
        }
    }
}
