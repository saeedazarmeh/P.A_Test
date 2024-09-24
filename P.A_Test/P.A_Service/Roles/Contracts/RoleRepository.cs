
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Roles;

namespace P.A_Service.Roles.Contracts
{
    public interface RoleRepository
    {
        void Add(Role role);
        Task<bool> IsRepeatedRole(string role);
        Task<Role> Get(int id);
        Task<List<Role>> GetRolesWithPermission();
        Task<Role> GetRoleWithPermission(int id);
    }
}
