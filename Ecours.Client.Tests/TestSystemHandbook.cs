using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecours.Proxy;
using System.ServiceModel;

namespace Ecours.Client.Tests
{
    [TestFixture]
    public class TestSystemHandbook
    {

        [Test]
        public void TestInsert()
        {

            string uri = String.Format("net.tcp://{0}:{1}/SystemHandBook", "terminalserver", 40043);

            EndpointAddress endpoint_m = new EndpointAddress(new Uri(uri));

            NetTcpBinding binding_m = new NetTcpBinding(SecurityMode.None);

            using (SystemHandbookClient systemHandbook = new SystemHandbookClient(binding_m, endpoint_m))
            {
              
                   bool res = systemHandbook.NewOkato(new OKATO(1, "Test Okato"));

                    Assert.AreEqual(true, res);
              
            }
        }
    
    }
}
