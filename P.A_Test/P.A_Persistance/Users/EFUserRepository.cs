using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P.A._Entity.Users;
using P.A_Service.Users.Contracts;

namespace P.A_Persistance.Users
{
    public class EFUserRepository:UserRepository
    {
        private readonly EFDataContext _context;

        public EFUserRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> GetUserWithPersonels(int id)
        {
            return await _context.Users.Include(u => u.Personels).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone);
        }

        public async Task<UserToken> GetUserToken(string hashedToken)
        {
            return await _context.UserTokens.FirstOrDefaultAsync(u => u.HashedToken == hashedToken);
        }

        public async Task<User> GetUserwhithUserRoles(int id)
        {
            return await _context.Users.Include(u => u.UserRoles).FirstOrDefaultAsync(u => u.Id == id);
        }

        public bool IsRepeatedPhoneNumber(string phoneNumber)
        {
            return  _context.Users.Any(u => u.Phone == phoneNumber);
        }
    }
}
