using P.A_Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A_Service.Users.Contracts.Exceptions;

namespace P.A_Service.Users.Contracts.DTOs
{
    public class AddUserDTO
    {
        public AddUserDTO(string name, string family, string phone, string? email, string password, string confirmPassword)
        {
            Guard(phone, email,password,confirmPassword);
            Name = name;
            Family = family;
            Phone = phone;
            Email = email;
            Password= password;
            ConfirmPassword= confirmPassword;
        }

        [MinLength(3, ErrorMessage = "Phone min size is 3 char")]
        [MaxLength(20, ErrorMessage = "Phone max size is 20 char")]
        public string Name { get;  set; }

        [MinLength(3, ErrorMessage = "Phone min size is 3 char")]
        [MaxLength(25, ErrorMessage = "Phone max size is 25 char")]
        public string Family { get;  set; }

        [MinLength(11, ErrorMessage = "Phone min size is 11 char")]
        [MaxLength(11, ErrorMessage = "Phone max size is 11 char")]
        public string Phone { get;  set; }
        [MinLength(8, ErrorMessage = "min size is 8 char")]
        [MaxLength(15, ErrorMessage = "max size is 15 char")]
        public string Password { get;  set; }
        public string ConfirmPassword { get;  set; }
        public string? Email { get;  set; }
        public void Guard(string phone,string email, string password, string confirmPassword)
        {
            if (!Utility.IsValidPhoneNumber(phone))
            {
                throw new InvalidUserDataException("Please insert an valid PhoneNumber");
            }
            else if (Email != null && !Utility.IsValidEmail(email))
            {
                throw new InvalidUserDataException("Please insert an valid EmailAddress");
            }
            else if (!Utility.IsValidPassword(password))
            {
                throw new InvalidUserDataException("Please insert an valid Password");
            }
            else if (password != confirmPassword)
            {
                throw new InvalidUserDataException("Password And ConfirmPassword Are Not Equal");
            }
        }
       

    }
}
