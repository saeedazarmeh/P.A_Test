using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A._Entity.Users
{
    public class UserRole
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int RoleId { get; private set; }

        public UserRole(int roleId)
        {
            RoleId=roleId;
        }
    }
}
