using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailAWSES.Models
{
    public class EmailModel
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
