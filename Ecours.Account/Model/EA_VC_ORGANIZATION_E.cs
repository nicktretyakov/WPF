using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Proxy
{
    public partial class EA_VC_ORGANIZATION : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        public EA_VC_ORGANIZATION(long loginid) {

            this.Loginid = loginid;
        }

        public EA_VC_ORGANIZATION(long loginid, String shortname) {

            this.Loginid = loginid;

            this.Shortname = shortname;
        }
    }
}
