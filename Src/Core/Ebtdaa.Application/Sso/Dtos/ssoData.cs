using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Sso.Dtos
{
    public class ssoData
    {
        public string NationalID { get; set; }
        public string Name { get; set; }

    }
    public class LoginDataRequest
    {
        public string token { get; set; }
        public string signature { get; set; }
        public string uuid { get; set; }

    }
}
