using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts.DTOs
{
    public class AddTokenDTO
    {
        public string HashedToken { get; private set; }
        public DateTime ExpierdHashedTokenDate { get; private set; }

        public AddTokenDTO(string hashedToken, DateTime expierdHashedTokenDate)
        {
            HashedToken = hashedToken;
            ExpierdHashedTokenDate = expierdHashedTokenDate;
        }

        public void Guard(DateTime expierdHashedTokenDate, DateTime expierdHashedRefreshTokenDate)
        {

            if (expierdHashedTokenDate <= DateTime.Now)
                throw new InvalidDataException("ExpierdTokenDate is wrong");
        }
    }
}
