using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBeaconReceiver.Models
{
    public class iBeaconAdvertisingPacket : BindableBase
    {
        private DateTime _LastScanDateTime;
        public DateTime LastScanDateTime
        {
            get { return _LastScanDateTime; }
            set { SetProperty(ref _LastScanDateTime, value); }
        }

        private int _CompanyId;
        public int CompanyId
        {
            get { return _CompanyId; }
            set { SetProperty(ref _CompanyId, value); }
        }

        private string _Uuid;
        public string Uuid
        {
            get { return _Uuid; }
            set { SetProperty(ref _Uuid, value); }
        }

        private int _Major;
        public int Major
        {
            get { return _Major; }
            set { SetProperty(ref _Major, value); }
        }

        private int _Minor;
        public int Minor
        {
            get { return _Minor; }
            set { SetProperty(ref _Minor, value); }
        }

        private int _SignalPower;
        public int SignalPower
        {
            get { return _SignalPower; }
            set { SetProperty(ref _SignalPower, value); }
        }

        private int _TxPower;
        public int TxPower
        {
            get { return _TxPower; }
            set { SetProperty(ref _TxPower, value); }
        }
    }
}
