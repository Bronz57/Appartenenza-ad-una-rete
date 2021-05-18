using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_BronzettiChristian_Verificasottoreti;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //es1 
        //Network: 192.168.1.0
        //Subnet mask: 255.255.255.0
        
        //192.168.1.20 AND subnet_mask = 192.168.1.0
        //quindi appartiene alla rete
        [TestMethod]
        public void Appartiene1()
            => Assert.AreEqual(SottoRete.VerificaAppartenenza("192.168.1.0", "255.255.255.0", "192.168.1.20"), true);


        //192.167.1.20 AND subnet_mask = 192.167.1.0
        //quindi non appartiene alla rete

        [TestMethod]
        public void NonAppartiene1()
            => Assert.AreEqual(SottoRete.VerificaAppartenenza("192.168.1.0", "255.255.255.0", "192.167.1.20"), false);

        //es 2
        // Network: 192.64.0.0
        //Subnet mask: 255.192.0.0
        
        //192.64.1.2 AND subnet_mask = 192.64.0.0
        //quindi appartiene alla rete
        [TestMethod]
        public void Appartiene2()
            => Assert.AreEqual(SottoRete.VerificaAppartenenza("192.64.0.0", "255.192.0.0", "192.65.1.2"), true);

        
        //192.128.1.2 AND subnet_mask = 192.128.0.0
        //quindi non appartiene alla rete
        [TestMethod]
        public void NonAppartiene2()
            => Assert.AreEqual(SottoRete.VerificaAppartenenza("192.64.0.0", "255.192.0.0", "192.128.1.2"), false);


    }
}
