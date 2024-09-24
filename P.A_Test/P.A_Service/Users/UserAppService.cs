using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Roles;
using P.A._Entity.Roles.Enums;
using P.A._Entity.Users;
using P.A_Contract.InfraStucture;
using P.A_Contract.Service.SecurityUtil;
using P.A_Service.Roles.Contracts;
using P.A_Service.Users.Contracts;
using P.A_Service.Users.Contracts.DTOs;
using P.A_Service.Users.Contracts.Exceptions;
using P.A_Service.Users.UserMapper;

namespace P.A_Service.Users
{
    public class UserAppService : UserService
    {
        private readonly UserRepository _repository;
        private readonly UnitOfWork _unit;
        private readonly RoleRepository _roleRepository;

        public UserAppService(UserRepository repository, UnitOfWork unit,RoleRepository roleRepository)
        {
            _repository = repository;
            _unit = unit;
            _roleRepository = roleRepository;
        }

        public async Task RegisterUser(AddUserDTO dto)
        {
            if (!_repository.IsRepeatedPhoneNumber(dto.Phone))
            {
                var user = new User(dto.Name, dto.Family, dto.Phone, dto.Email, PasswordHelper.EncodePasswordMd5(dto.Password));
                await _unit.Begin();
                try
                {
                    _repository.Add(user);
                    var role = new Role("Admin");
                    _roleRepository.Add(role);
                    await _unit.Complete();
                    role.AddPermission(new RolePermission(Permissions.Admin));
                    await _unit.Complete();
                    user.AddRole(new UserRole(role.Id));
                    await _unit.Complete();
                    await _unit.Commit();
                }
                catch (Exception e)
                {
                    await _unit.RollBack();
                }
            }
            else
            {
                throw new PhoneNumberisRepeatedException();
            }

        }


        public async Task AddPersonel(AddPersonelDTO dto, int userId)
        {
            if (!_repository.IsRepeatedPhoneNumber(dto.Phone))
            {
                var user = await _repository.GetUser(userId);
                var personel = new User(dto.Name, dto.Family, dto.Phone, dto.Email);
                await _unit.Begin();
                try
                {
                    user.AddPersonel(personel);
                    var role = new Role("Personel");
                    _roleRepository.Add(role);
                    await _unit.Complete();
                    role.AddPermission(new RolePermission(Permissions.Personel));
                    await _unit.Complete();
                    personel.AddRole(new UserRole(role.Id));
                    await _unit.Complete();
                    await _unit.Commit();
                }
                catch (Exception e)
                {
                    await _unit.RollBack();
                }
            }
            else
            {
                throw new PhoneNumberisRepeatedException();
            }

        }

        public async Task UpdateUserOrPersonelInfo(UpdateUserOrPersonelInfoDTO dto)
        {
            var user = await _repository.GetUser(dto.Id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.Edit(dto.Name, dto.Family, dto.Email);
            await _unit.Complete();
        }

        public async Task RemovePersonel(int personelId, int userId)
        {
            var user = await _repository.GetUserWithPersonels(userId);
            var personel = await _repository.GetUser(personelId);
        
            if (personel != null)
            {
                if (user.Personels.Contains(personel))
                {
                    user.RemovePersonel(personel);
                    await _unit.Complete();
                }
            }
            else
            {
                throw new UserNotFoundException();
            }

        }
        public async Task RemoveUserToken(UserToken token)
        {
            var user = await _repository.GetUser(token.UserId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.RemoveToken(token);
            await _unit.Complete();
        }

        public async Task AddUserToken(int userId, AddTokenDTO dto)
        {
            var user = await _repository.GetUser(userId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.AddToken(new UserToken(dto.HashedToken, dto.ExpierdHashedTokenDate));
            await _unit.Complete();
        }

        public async Task<UserToken> GetUserHashedToken(string hashedToken)
        {
            var token = await _repository.GetUserToken(hashedToken);
            if (token == null)
            {
                throw new Exception("Token not found");
            }

            return token;
        }

        public async Task<List<UserResultDTO>> GetUsersPersonels(int id)
        {
            var user = await _repository.GetUserWithPersonels(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user.Personels.PersonelssMapper();
        }

        public async Task<UserResultDTO> GetUserByPhone(string phone)
        {
            var user = await _repository.GetUserByPhone(phone);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user.UserMapper();
        }

        public async Task<User> GetUserWithUserRoles(int id)
        {
            var user = await _repository.GetUserwhithUserRoles(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }
    }
}
