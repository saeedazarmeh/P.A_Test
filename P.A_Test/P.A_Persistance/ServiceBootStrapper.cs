using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A_Contract.InfraStucture;
using P.A_Persistance.Roles;
using P.A_Persistance.Users;
using P.A_Service.Roles.Contracts;
using P.A_Service.Users;
using P.A_Service.Users.Contracts;


namespace P.A_Persistance
{
    public static class ServiceBootStrapper
    {
        public static void ServiceInit(this IServiceCollection services)
        {
            services.AddScoped<UserRepository, EFUserRepository>();
            services.AddScoped<UserService, UserAppService>();
            services.AddScoped<RoleRepository,EFRoleRepository>();
            services.AddScoped<UnitOfWork,EFUnitOfWork>();

        }
    }
}
