using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A._Entity.Users
{
    public class UserToken
    {
        public UserToken(string hashedToken, DateTime expierdHashedTokenDate)
        {
            HashedToken = hashedToken;
            ExpierdHashedTokenDate = expierdHashedTokenDate;
            CreationDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string HashedToken { get; private set; }
        public DateTime ExpierdHashedTokenDate { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int UserId { get; private set; }
    }
}
