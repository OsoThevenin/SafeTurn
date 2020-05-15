using System.Threading.Tasks;
using Moq;
using SafeTurn.Application.Interfaces.Persistence;
using SafeTurn.Domain.User;
using Xunit;

namespace SafeTurn.Application.Auth.RegisterCommand
{
    public class RegisterTest
    {
        private readonly Mock<IUserRepository> _userRepo; 
        private readonly Register _service;

        public RegisterTest()
        {
            _userRepo = new Mock<IUserRepository>();
            _service = new Register(_userRepo.Object);
        }

        [Fact]
        public async Task RegisterAsync()
        {
            var model = new RegisterModel()
            {
                Email = "asd@asd.com",
                Password = "asdASD123.",
                RepeatPassword = "asdASD123.",
                Name = "name",
                Surname = "surname"
            };
            _userRepo.Setup(x => x.CreateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Verifiable();
            await _service.ExecuteAsync(model);

            _userRepo.VerifyAll();
        }

        [Fact]
        public async Task RegisterWrongEmailAsync()
        {
            var model = new RegisterModel()
            {
                Email = "asdasd.com",
                Password = "asdASD123.",
                RepeatPassword = "asdASD123.",
                Name = "name",
                Surname = "surname"
            };
            // _userRepo.Setup(x => x.CreateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).
            //     Throws(new UserExceptionCreateUser())
            //     .Verifiable();
            await Assert.ThrowsAsync<RegisterExceptionWrongRepeat>(() => _service.ExecuteAsync(model));
            await _service.ExecuteAsync(model);

            _userRepo.VerifyAll();
        }

        [Fact]
        public void RegisterEmailNotExist()
        {
            
        }

        [Fact]
        public void RegisterInvalidPassword()
        {

        }

        [Fact]
        public async Task RegisterWrongRepeatPasswordAsync()
        {
            var model = new RegisterModel()
            {
                Email = "asd@asd.com",
                Password = "asdASD123.",
                RepeatPassword = "123.",
                Name = "name",
                Surname = "surname"
            };

            await Assert.ThrowsAsync<RegisterExceptionWrongRepeat>(() => _service.ExecuteAsync(model));
            _userRepo.VerifyAll();
        }

        [Fact]
        public void RegisterAlreadyExist()
        {
            
        }
    }
}