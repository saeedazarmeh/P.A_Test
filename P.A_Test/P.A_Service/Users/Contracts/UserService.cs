using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Users;
using P.A_Service.Users.Contracts.DTOs;
using P.A_Service.Users.Contracts.Exceptions;

namespace P.A_Service.Users.Contracts
{
    public interface UserService
    {
        Task RegisterUser(AddUserDTO dto);
        Task AddPersonel(AddPersonelDTO dto, int userId);
        Task UpdateUserOrPersonelInfo(UpdateUserOrPersonelInfoDTO dto);
        Task RemovePersonel(int personelId,int userId);
        Task RemoveUserToken(UserToken token);

        Task AddUserToken(int userId, AddTokenDTO dto);
        

        Task<UserToken> GetUserHashedToken(string hashedToken);

        Task<List<UserResultDTO>> GetUsersPersonels(int id);
        Task<UserResultDTO> GetUserByPhone(string phone);
        Task<User> GetUserWithUserRoles(int id);
    }
}
