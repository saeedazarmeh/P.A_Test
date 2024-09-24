using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts.Exceptions
{
    public class InvalidUserDataException:Exception
    {
        public InvalidUserDataException()
        {

        }
        public InvalidUserDataException(string message) : base(message)
        {

        }
    }
}
