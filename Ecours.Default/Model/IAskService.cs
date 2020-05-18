using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.Model
{ 
    public interface IAskService
    {
        Task ToSend(Ask ask);
    }
}
