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
    public class UpdateUserOrPersonelInfoDTO
    {
            public UpdateUserOrPersonelInfoDTO(string name, string family, string phone, string? email)
            {
                Guard(phone, email);
                Name = name;
                Family = family;
                Phone = phone;
                Email = email;
            }
            public int Id { get; private set; }
        [MinLength(3, ErrorMessage = "Phone min size is 3 char")]
            [MaxLength(20, ErrorMessage = "Phone max size is 20 char")]
            public string Name { get; private set; }

            [MinLength(3, ErrorMessage = "Phone min size is 3 char")]
            [MaxLength(25, ErrorMessage = "Phone max size is 25 char")]
            public string Family { get; private set; }

            [MinLength(11, ErrorMessage = "Phone min size is 11 char")]
            [MaxLength(11, ErrorMessage = "Phone max size is 11 char")]
            public string Phone { get; private set; }
            public string? Email { get; private set; }
            public int? UserId { get; private set; }
        public void Guard(string phone, string email)
            {
                if (!Utility.IsValidPhoneNumber(phone))
                {
                    throw new InvalidUserDataException("Please insert an valid PhoneNumber");
                }
                else if (Email != null && !Utility.IsValidEmail(email))
                {
                    throw new InvalidUserDataException("Please insert an valid EmailAddress");
                }
            }
    }
}
