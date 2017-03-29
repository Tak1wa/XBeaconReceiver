using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBeaconReceiver.Models
{
    public static class iBeaconAdvertisingPacketConverter
    {
        public static bool IsiBeaconAdvertisingPacket(this byte[] bytes)
        {
            if (bytes == null) return false;
            return bytes.Length >= 25;
        }

        public static iBeaconAdvertisingPacket ToiBeaconAdvertisingPacket(this byte[] bytes)
        {
            var packet = new iBeaconAdvertisingPacket();
            var manufacturerArray = bytes.Skip(0).Take(2).ToArray();
            //var what = bytes.Skip(2).Take(2).ToArray();
            var uuidArray1 = bytes.Skip(4).Take(4).ToArray();
            var uuidArray2 = bytes.Skip(8).Take(4).ToArray();
            var uuidArray3 = bytes.Skip(12).Take(4).ToArray();
            var uuidArray4 = bytes.Skip(16).Take(4).ToArray();
            var majorArray = bytes.Skip(20).Take(2).ToArray();
            var minorArray = bytes.Skip(22).Take(2).ToArray();

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(manufacturerArray);
                Array.Reverse(uuidArray1);
                Array.Reverse(uuidArray2);
                Array.Reverse(uuidArray3);
                Array.Reverse(uuidArray4);
                Array.Reverse(majorArray);
                Array.Reverse(minorArray);
            }

            packet.CompanyId = BitConverter.ToInt16(manufacturerArray, 0);
            packet.Uuid = $"{BitConverter.ToInt32(uuidArray1, 0).ToString("x")}-{BitConverter.ToInt32(uuidArray2, 0).ToString("x")}-{BitConverter.ToInt32(uuidArray3, 0).ToString("x")}-{BitConverter.ToInt32(uuidArray4, 0).ToString("x")}";
            packet.Major = BitConverter.ToInt16(majorArray, 0);
            packet.Minor = BitConverter.ToInt16(minorArray, 0);
            //packet.SignalPower = bytes.Last();
            packet.SignalPower = -4;
            packet.LastScanDateTime = DateTime.Now;

            return packet;
        }
    }
}
