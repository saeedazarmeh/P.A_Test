using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Roles.Contracts.DTO.RolePermissions
{
    public class RemovePermissonDTO
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
    }
}
