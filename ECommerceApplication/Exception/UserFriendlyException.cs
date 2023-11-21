using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Exception
{
    [Serializable]
    public class UserFriendlyException : System.Exception
    {
        public string Details { get; private set; }

        public UserFriendlyException(string message) : base(message) { }

        public UserFriendlyException(string message, System.Exception inner) : base(message, inner)
        {

        }
        public UserFriendlyException(string message, string details) : this(message)
        {
            Details = details;
        }
    }
}
