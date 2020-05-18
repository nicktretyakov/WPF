using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Proxy
{
    public partial class OKATO: object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        public OKATO(int id, string OkatoName)
        {
            this.Id = id;
            this.Okato_Name = OkatoName;
        }
    }
}
