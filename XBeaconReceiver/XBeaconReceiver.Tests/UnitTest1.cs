using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XBeaconReceiver.Models;

namespace XBeaconReceiver.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private byte[] CreateTestData()
        {
            var input = new byte[]
            {
                76,
                0,
                2,
                21,
                197,
                137,
                37,
                169,
                209,
                120,
                68,
                169,
                142,
                94,
                183,
                23,
                230,
                237,
                232,
                139,
                0,
                2,
                4,
                210,
                195
            };
            return input;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var advertisingPacket = CreateTestData().ToiBeaconAdvertisingPacket();
            Assert.AreEqual("2", advertisingPacket.Major.ToString());
            Assert.AreEqual("1234", advertisingPacket.Minor.ToString());
            Assert.AreEqual("c58925a9-d17844a9-8e5eb717-e6ede88b", advertisingPacket.Uuid);
            Assert.AreEqual("19456", advertisingPacket.CompanyId.ToString());
            Assert.AreEqual("-4", advertisingPacket.SignalPower.ToString());
        }
    }
}
