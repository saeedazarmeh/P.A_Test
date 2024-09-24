using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A._Entity.Users
{
    public class User
    {
        public User(string name, string family, string phone, string? email,string password)
        {
            Name = name;
            Family = family;
            Phone = phone;
            Email = email;
            Password = password;
        }
        public User(string name, string family, string phone, string? email)
        {
            Name = name;
            Family = family;
            Phone = phone;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public List<UserRole> UserRoles { get; set; }=new List<UserRole>();
        public int? UserId { get; private set; }
        public List<User> Personels { get; set; } = new List<User>();
        public List<UserToken> UserTokens { get; set; } = new List<UserToken>();


        public void Edit(string name, string family, string? email)
        {
            Name=name;
            Family=family;
            Email=email;
        }

        public void ChangePhoneAndPass(string phone)
        {
            Phone=phone;
        }

        public void AddRole(UserRole role)
        {
            UserRoles.Add(role);
        }
        public void RemoveRole(UserRole role)
        {
            UserRoles.Remove(role);
        }

        public void AddPersonel(User user)
        {
            Personels.Add(user);
        }
        public void RemovePersonel(User user)
        {
            Personels.Remove(user);
        }

        public void AddToken(UserToken token)
        {
            UserTokens.Add(token);
        }
        public void RemoveToken(UserToken token)
        {
            UserTokens.Remove(token);
        }
    }
}
