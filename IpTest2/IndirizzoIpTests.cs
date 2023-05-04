using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IpTest2;
using IpGeneratorV2;

namespace IpTest2
{
    [TestClass]
    public class IndirizzoIpTests
    {
        int bit = 30;
        [TestMethod]
        public void VerificaBitCorretti()
        {
            AddressGenerator ip1 = new AddressGenerator(bit);
            Assert.AreEqual(bit, ip1.GetBit(),"Bit impostati incorrettamente");
        }
    }
}
