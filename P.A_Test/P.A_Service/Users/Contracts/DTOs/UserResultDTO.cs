using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts.DTOs
{
    public class UserResultDTO
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
