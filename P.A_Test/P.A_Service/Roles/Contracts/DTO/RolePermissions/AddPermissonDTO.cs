
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using P.A._Entity.Roles.Enums;

namespace P.A_Service.Roles.Contracts.DTO.RolePermissions
{
    public class AddPermissonDTO
    {
        public int RoleId { get; set; }
        public Permissions Permissions { get; set; }

    }
}
