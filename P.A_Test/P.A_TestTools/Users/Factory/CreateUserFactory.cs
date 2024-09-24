using P.A._Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_TestTools.Users.Factory
{
    public class CreateUserFactory
    {
        public static User Create(string name, string family, string phone, string pass)
        {
            return new User(name, family, phone, null, pass);
        }
    }
}
