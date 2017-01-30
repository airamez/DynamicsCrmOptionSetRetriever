using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DyanmicsCrmOptionSetRetriever;

namespace DynamicsCrmOptionSetRetrieverTest
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("contact", "optionset1", "string1").Value, 1);
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("CONTACT", "OPTIONSET1", "STRING2").Value, 2);
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("coNTact", "opTionSET1", "sTRing4").Value, 4);

            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("contact", "optionset2", "string1").Value, 1);
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("CONTACT", "OPTIONSET2", "STRING2").Value, 2);
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("coNTact", "opTionSET2", "sTRing4").Value, 4);

            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("ACCOUNT", "optionset1", "string5").Value, 5);
            Assert.AreEqual<int>(CrmOptionSetRetriever.GetOptionFromExternalString("AccouNT", "optionset1", "string8").Value, 8);
        }
    }
}
