
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Roles.Contracts.DTO.Roles
{
    public class AddRoleDTO
    {
        public AddRoleDTO(string title)
        {
            Title = title;
        }

        [Required]
        [MaxLength(50, ErrorMessage = "Role size is 50 charector")]
        public string Title { get; set; }

    }
}
