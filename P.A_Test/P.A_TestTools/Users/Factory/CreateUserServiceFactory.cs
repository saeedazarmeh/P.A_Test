using P.A_Persistance.Roles;
using P.A_Persistance.Users;
using P.A_Persistance;
using P.A_Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_TestTools.Users.Factory
{
    public class CreateUserServiceFactory
    {
        public static UserAppService Create(EFDataContext context)
        {
            var userRepository = new EFUserRepository(context);
            var roleRepository = new EFRoleRepository(context);
            var unit = new EFUnitOfWork(context);
            return new UserAppService(userRepository, unit, roleRepository);
        }
    }
}
