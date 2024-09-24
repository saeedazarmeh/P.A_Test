using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Users;
using P.A_Service.Users.Contracts.DTOs;

namespace P.A_TestTools.Users.Factory
{
    public class CreateAddUserDTOFactory
    {
        public static AddUserDTO Create(string name,string family,string phone,string pass,string conpass)
        {
            return new AddUserDTO(name,family,phone,null,pass,conpass);
        }
    }
 

}
