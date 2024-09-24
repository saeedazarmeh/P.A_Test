using P.A_TestTools.InfraStructure.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using P.A_Service.Users.Contracts.Exceptions;
using P.A_TestTools.Users.Factory;

namespace P.A_UnitTest
{
    public class UserServiceTest: BusinessUnitTest
    {
        [Fact]
        public async Task AddUser_Should_Added_Prperly()
        {
            string Name = "Saeed";
            string Family = "Azarmehr";
            string Phone = "09394855831";
            string Password = "Saeed2280@";
            string ConPassword = "Saeed2280@";
            var userDTO = CreateAddUserDTOFactory.Create(Name,Family,Phone,Password,ConPassword);
            var sut = CreateUserServiceFactory.Create(DbContext);

            await sut.RegisterUser(userDTO);

            var user = ReadContext.Users.First();
            user.Name.Should().Be(Name);
            user.Family.Should().Be(Family);
            user.Phone.Should().Be(Phone);
        }

        [Fact]
        public async Task AddUser_Should_throw_An_PhoneNumberisRepeatedException_Because_Of_Repeated_PhoneNumber()
        {
            string Name = "Saeed";
            string Family = "Azarmehr";
            string Phone = "09394855831";
            string Password= "Saeed2280@";
        
            var user1 = CreateUserFactory.Create(Name, Family, Phone, Password);
            string Name2 = "Ali";
            string Family2 = "Azarmehr";
            string Phone2 = "09394855831";
            string Password2 = "Saeed2280@";
            string ConPassword2 = "Saeed2280@";
            var userDTO = CreateAddUserDTOFactory.Create(Name2, Family2, Phone2, Password2, ConPassword2);
            var sut = CreateUserServiceFactory.Create(DbContext);
          
            

            DbContext.Save(user1);
            var actual = () => sut.RegisterUser(userDTO);

            await actual.Should().ThrowAsync<PhoneNumberisRepeatedException>();
        }

        [Fact]
        public async Task AddPersonel_Should_Added_Prperly()
        {
            string Name = "Saeed";
            string Family = "Azarmehr";
            string Phone = "09394855831";
            string Password = "Saeed2280@";

            var user1 = CreateUserFactory.Create(Name, Family, Phone, Password);
            string Name2 = "Ali";
            string Family2 = "Azarmehr";
            string Phone2 = "09179251859";
            var userDTO = CreateAddPersonelDTOFactory.Create(Name2, Family2, Phone2);
            var sut = CreateUserServiceFactory.Create(DbContext);



            DbContext.Save(user1);
            await sut.AddPersonel(userDTO,user1.Id);

            var personels = ReadContext.Users.ToList();
            personels[0].UserId.Should().Be(null);
            personels[1].UserId.Should().Be(user1.Id);
        }
    }
}
