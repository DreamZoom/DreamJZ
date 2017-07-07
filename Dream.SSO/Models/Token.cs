using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dream.SSO.Models
{
    public class Token : EntityBase
    {
        public string TokenID { get; set; }

        public DateTime ValidTime { get; set; }

        public string RemoteIp { get; set; }

        public string UserName { get; set; }

        public bool IsValid { get; set; }
    }
}
