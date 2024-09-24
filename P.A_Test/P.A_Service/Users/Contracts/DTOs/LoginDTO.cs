using P.A_Contract;
using P.A_Service.Users.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts.DTOs
{
    public class LoginDTO
    {
        public LoginDTO(string phone,  string password)
        {
            Guard(phone, password);
            Phone = phone;
            Password = password;
        }

        [MinLength(11, ErrorMessage = "Phone min size is 11 char")]
        [MaxLength(11, ErrorMessage = "Phone max size is 11 char")]
        public string? Phone { get; private set; }

        [MinLength(8, ErrorMessage = "min size is 8 char")]
        [MaxLength(15, ErrorMessage = "max size is 15 char")]
        public string Password { get; private set; }


        public void Guard(string phone, string password)
        {
            if (!Utility.IsValidPassword(password))
            {
                throw new InvalidUserDataException("Please insert an valid Password");
            }
        }
    }
}
