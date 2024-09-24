using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P.A._Entity.Users;
using P.A_Service.Users.Contracts.DTOs;

namespace P.A_Service.Users.UserMapper
{
    public static class UserMap
    {
        public static List<UserResultDTO> PersonelssMapper(this List<User> personels)
        {
            personels=personels.OrderBy(u=>u.Name).ThenBy(u=>u.Family).ToList();
            var personelsDTO=new List<UserResultDTO>();
            foreach (var personel in personels)
            {
                var personelDTO=new UserResultDTO()
                {
                    Id=personel.Id,
                    Name = personel.Name,
                    Family = personel.Family,
                    Phone = personel.Phone,
                    Email = personel.Email,
                };
                personelsDTO.Add(personelDTO);
            }
            return  personelsDTO;
        }
        public static UserResultDTO UserMapper(this User user)
        {
            var userDTO = new UserResultDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Family = user.Family,
                Phone = user.Phone,
                Email = user.Email,
                Password = user.Password
            };
            return userDTO;
        }
    }
   
}
