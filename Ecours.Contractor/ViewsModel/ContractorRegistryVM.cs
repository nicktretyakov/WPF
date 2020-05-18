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

namespace Ecours.Contractor.ViewsModel
{
    public class ContractRegistryVM : BindableBase
    {
        private static String GetUri()
        {
            Hashtable dsh = (Hashtable)ConfigurationManager.GetSection("ContractorSpecs");
            string uri = String.Format("net.tcp://{0}:{1}/Contractor", dsh["Host"], dsh["TcpPort"]);

            return uri;
        }

        public static readonly EndpointAddress endpoint_m = new EndpointAddress(new Uri(GetUri()));

        public static readonly NetTcpBinding binding_m = new NetTcpBinding(SecurityMode.None);

        public static bool TestService()
        {

            bool isServiceUp = false;
            try
            {

                using (ServiceContractorClient serviceContractor = new ServiceContractorClient(binding_m, endpoint_m))
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

        private readonly ObservableCollection<ContractRegistry> listContractRegistry_m;

        private ContractRegistry contractRegistry_m;

        public ContractRegistry CurrentContractRegistry
        {
            get { return contractRegistry_m; }
            set { contractRegistry_m = value; }
        }
        public ObservableCollection<ContractRegistry> ListContractRegistry => listContractRegistry_m;

        public ContractRegistryVM(long offset, long fetch)
        {
            using (ServiceContractorClient serviceContractor = new ServiceContractorClient(binding_m, endpoint_m))
            {
                try
                {
                    // listContractRegistry_m = new ObservableCollection<ContractRegistry>(serviceContractor.ListContractRegistry(offset, fetch));
                    listContractRegistry_m = new ObservableCollection<ContractRegistry>(serviceContractor.All());
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
     
        public void Insert()
        {
            using (ServiceContractorClient serviceContractor = new ServiceContractorClient(binding_m, endpoint_m))
            {
                try
                {
                    serviceContractor.Insert(CurrentContractRegistry);
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
    }
}
