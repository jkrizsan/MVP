using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVP.API.Helpers
{
    public interface IEmailHelper
    {
        bool SendMail(string message, string target);
    }
}
