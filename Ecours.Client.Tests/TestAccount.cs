using Ecours.Account.ViewsModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Client.Tests
{
    [TestFixture]
    public class TestAccount
    {
        [Test]
        public void TestDelete()
        {

            AccountVM.TestService();

            AccountVM accountVM = new AccountVM(50, 0);

            accountVM.GetAccount(-500);            

            accountVM.Delete();

            Object res = accountVM.GetAccount(-500);

            Assert.IsNull(res);
        }

        [Test]
        public void TestInsert()
        {
        
            AccountVM accountVM = new AccountVM(50, 0);

            accountVM.CurrentAccount = new Proxy.EA_VC_ORGANIZATION(-500, "Иванов");

            accountVM.Insert();

            Object res = accountVM.GetAccount(-500);

            Assert.IsNotNull(res);
        }

        [Test]
        public void TestUpdate()
        {

            AccountVM accountVM = new AccountVM(50, 0);

            accountVM.GetAccount(-100);

            accountVM.CurrentAccount.Shortname = "Иванов";

            accountVM.Update();

            accountVM.GetAccount(-100);

            Assert.AreEqual("Иванов", accountVM.CurrentAccount.Shortname);
        }
        [Test]
        public void TestService()
        {
            bool res = AccountVM.TestService();

            Assert.AreEqual(true, res);
        }
    }
}
