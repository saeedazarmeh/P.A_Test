
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Roles;
using P.A_Service.Roles.Contracts;

namespace P.A_Persistance.Roles
{
    public class EFRoleRepository : RoleRepository
    {
        private readonly EFDataContext _context;

        public EFRoleRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Role role)
        {
            _context.Roles.Add(role);
        }

        public async Task<Role> Get(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> IsRepeatedRole(string role)
        {
            return await _context.Roles.AnyAsync(u => u.Title == role);
        }

        public async Task<List<Role>> GetRolesWithPermission()
        {
            return await _context.Roles.Include(r => r.RolePermissions).ToListAsync();
        }

        public async Task<Role> GetRoleWithPermission(int id)
        {
            return await _context.Roles.Include(r => r.RolePermissions).FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
