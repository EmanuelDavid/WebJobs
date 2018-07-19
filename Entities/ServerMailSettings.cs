using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJob.Entities
{
    internal class ServerMailSettings
    {
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Body{ get; set; }
        public string Password { get; set; }
    }
}
