using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecours.Default.Model
{
    public class Ask {

        private String ORG_NAME;

        private String CONTACT;

        private String CONTACT_POSITION;

        private String PHONE;

        private String EMAIL;

        private bool PRIORITY_PHONE; // Предпочительный способ связи (true-тел.,false-емаил)

        private short? SROK;

        private String QUESTION;

        private byte[] ATTACHMENT;

    }

    public class AskService : IAskService
    {        
        public Task ToSend(Ask ask)
        {
            throw new NotImplementedException();
        }
    }
}
