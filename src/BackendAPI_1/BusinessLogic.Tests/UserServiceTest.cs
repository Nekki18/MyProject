using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            // arrange
            var newUser = new User()
            {
                Firstname = "Test",
                Lastname = "Test",
                Middlename = "Test",
                Birthdate = DateTime.MaxValue,
                Login = "Test",
                Email = "test@test.com",
                Password = ""
            };

            // act
            await service.Create(newUser);

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
