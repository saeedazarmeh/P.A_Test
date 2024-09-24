using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P.A._Entity.Roles;
using P.A._Entity.Users;

namespace P.A_Persistance
{
    public class EFDataContext:DbContext
    {
        public EFDataContext(string connectionString) :
            this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {
        }


        public EFDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(EFDataContext).Assembly);
        }
    }
}
