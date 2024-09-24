using P.A_Service.Users.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_TestTools.Users.Factory
{
    public class CreateAddPersonelDTOFactory
    {
        public static AddPersonelDTO Create(string name, string family, string phone)
        {
            return new AddPersonelDTO(name, family, phone, null);
        }
    }
}
