using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A._Entity.Roles
{
    public class Role
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public List<RolePermission> RolePermissions  { get;  set; }=new List<RolePermission>();

        public Role( string title)
        {
            Title = title;
        }

        public void AddPermission(RolePermission permission)
        {
            RolePermissions.Add(permission);
        }
        public void RemovePermission(RolePermission permission)
        {
            RolePermissions.Remove(permission);
        }
    }
}
