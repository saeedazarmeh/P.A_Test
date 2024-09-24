using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.A_Service.Users.Contracts.DTOs
{
    public class TokenResultDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public TokenResultDTO(string id, string userId, DateTime creationDate, string token, string refreshToken)
        {
            Id = id;
            UserId = userId;
            CreationDate = creationDate;
            Token = token;
            RefreshToken = refreshToken;
        }
        public TokenResultDTO()
        {
        }
    }
}
