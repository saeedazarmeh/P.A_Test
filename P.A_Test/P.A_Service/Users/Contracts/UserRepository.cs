using P.A._Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts
{
    public interface UserRepository
    {
        void Add(User user);
        void Remove(User user);
        Task<User> GetUserWithPersonels(int id);
        Task<User> GetUser(int id);
        Task<User> GetUserByPhone(string phone);
        Task<UserToken> GetUserToken(string hashedToken);
        Task<User> GetUserwhithUserRoles(int id);
        bool IsRepeatedPhoneNumber(string phoneNumber);
    }
}
