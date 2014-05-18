using System;
using CloudAskue.BusinessLogic.Contracts;
using CloudAskue.DataProviders;
using CloudAskue.DataProviders.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataProviders.Tests
{
    [TestClass]
    public class SchemeProviderTests
    {
        [TestMethod]
        public void Savemaket()
        {
            string cs = "mongodb://127.0.0.1/askue";
            ISchemeProvider schemeProvider = new SchemeProvider(cs);
            Guid calcId = Guid.NewGuid();
            Maket maket = new Maket();
            maket.Areas.Add(new Area() { Name = "test" });
            schemeProvider.SaveMaket(calcId, maket);
            var actualmaket = schemeProvider.GetCalcResult(calcId);
            Assert.AreEqual(maket.Areas[0].Name, actualmaket.Areas[0].Name);

        }
    }
}
