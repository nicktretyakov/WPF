using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Ecours.Proxy;
using Ecours.Utils.Logging;

namespace Ecours.Account.ViewsModel
{
    public class AccountVM : BindableBase
    {
        private static String GetUri()
        {
#if DEBUG
            string uri = String.Format("net.tcp://{0}:{1}/Organization", "terminalserver", 40042);
#else
            Hashtable dsh = (Hashtable)ConfigurationManager.GetSection("AccountSpecs");



            string uri = String.Format("net.tcp://{0}:{1}/Organization", dsh["Host"], dsh["TcpPort"]);
#endif
            return uri;
        }

        public static readonly EndpointAddress endpoint_m = new EndpointAddress(new Uri(GetUri()));

        public static readonly NetTcpBinding binding_m = new NetTcpBinding(SecurityMode.None);

        public static bool TestService()
        {

            bool isServiceUp = false;
            try
            {

                using (ServiceOrganizationClient serviceContractor = new ServiceOrganizationClient(binding_m, endpoint_m))
                {
                    isServiceUp = serviceContractor.Test();
                }
            }
            catch (TimeoutException ex)
            {
                Logger.Log.Error(ex.Message);
            }
            catch (FaultException ex)
            {
                Logger.Log.Error(ex.Message);
            }
            catch (CommunicationException ex)
            {
                Logger.Log.Error(ex.Message);
            }
            return isServiceUp;
        }

        private readonly ObservableCollection<EA_VC_ORGANIZATION> listAccount_m;

        private EA_VC_ORGANIZATION EA_VC_ORGANIZATION_m;

        public EA_VC_ORGANIZATION CurrentAccount
        {
            get { return EA_VC_ORGANIZATION_m; }
            set { EA_VC_ORGANIZATION_m = value; }
        }
        public ObservableCollection<EA_VC_ORGANIZATION> ListAccount => listAccount_m;

        public AccountVM(long fetch, long offset)
        {
            using (ServiceOrganizationClient serviceAccount = new ServiceOrganizationClient(binding_m, endpoint_m))
            {
                try
                {
                    // listContractRegistry_m = new ObservableCollection<ContractRegistry>(serviceContractor.ListContractRegistry(offset, fetch));
                    listAccount_m = new ObservableCollection<EA_VC_ORGANIZATION>(serviceAccount.Get(25, 0, ""));
                }
                catch (TimeoutException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (FaultException<FaultMessage> ex)
                {
                    Logger.Log.Error("Select is fail(FaultException<FaultMessage>)! " + ex.Detail.Message);
                }
                catch (FaultException ex)
                {
                    Logger.Log.Error("Select is fail(FaultException)! " + ex.Message);
                }
                catch (CommunicationException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Test is fail!" + ex.Message);
                }
            }
        }
     
        public void Insert()
        {
            using (ServiceOrganizationClient serviceContractor = new ServiceOrganizationClient(binding_m, endpoint_m))
            {
                try
                {
                    serviceContractor.Insert(CurrentAccount);
                }
                catch (TimeoutException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (FaultException<FaultMessage> ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException<FaultMessage>)! " + ex.Detail.Message);
                }
                catch (FaultException ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException)! " + ex.Message);
                }
                catch (CommunicationException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Test is fail!" + ex.Message);
                }
            }
        }

        public void Update()
        {
            using (ServiceOrganizationClient serviceContractor = new ServiceOrganizationClient(binding_m, endpoint_m))
            {
                try
                {
                    serviceContractor.Update(CurrentAccount);
                }
                catch (TimeoutException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (FaultException<FaultMessage> ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException<FaultMessage>)! " + ex.Detail.Message);
                }
                catch (FaultException ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException)! " + ex.Message);
                }
                catch (CommunicationException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Test is fail!" + ex.Message);
                }
            }
        }

        public void Delete()
        {
            using (ServiceOrganizationClient serviceContractor = new ServiceOrganizationClient(binding_m, endpoint_m))
            {
                try
                {
                    serviceContractor.Delete(CurrentAccount);
                }
                catch (TimeoutException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (FaultException<FaultMessage> ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException<FaultMessage>)! " + ex.Detail.Message);
                }
                catch (FaultException ex)
                {
                    Logger.Log.Error("Insert is fail(FaultException)! " + ex.Message);
                }
                catch (CommunicationException ex)
                {
                    Logger.Log.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Test is fail!" + ex.Message);
                }
            }
        }

        public EA_VC_ORGANIZATION GetAccount(long loginid)
        {
            using (ServiceOrganizationClient serviceAccount = new ServiceOrganizationClient(binding_m, endpoint_m))
            {
                try
                {
                    // listContractRegistry_m = new ObservableCollection<ContractRegistry>(serviceContractor.ListContractRegistry(offset, fetch));
                    CurrentAccount = serviceAccount.GetById(loginid);
                    return CurrentAccount;
                }
                catch (TimeoutException ex)
                {
                    Logger.Log.Error(ex.Message);
                    return null;
                }
                catch (FaultException<FaultMessage> ex)
                {
                    Logger.Log.Error("Select is fail(FaultException<FaultMessage>)! " + ex.Detail.Message);
                    return null;
                }
                catch (FaultException ex)
                {
                    Logger.Log.Error("Select is fail(FaultException)! " + ex.Message);
                    return null;
                }
                catch (CommunicationException ex)
                {
                    Logger.Log.Error(ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("Test is fail!" + ex.Message);
                    return null;
                }
            }
        }
    }
}
