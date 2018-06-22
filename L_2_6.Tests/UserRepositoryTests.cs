using L_2_6.Entities;
using L_2_6.Interfaces;
using NSubstitute;
using NUnit.Framework;
using SharedLib.Random;

namespace L_2_6.Tests
{
    public class UserRepositoryTests
    {
        private IWindowsLogger _logger;
        private IUserDataBase _userDataBase;

        private UserRepository _userRepository;
        private IBusinessValidator _validator;

        [SetUp]
        public void SetUp()
        {
            _userDataBase = Substitute.For<IUserDataBase>();
            _validator = Substitute.For<IBusinessValidator>();
            _logger = Substitute.For<IWindowsLogger>();

            _userRepository = new UserRepository(_userDataBase, _validator, _logger);
        }

        [Test]
        public void GetUserByLastNameWorksAsExpected()
        {
            //Arrange
            var lastName = Rnd.RandomLastName;
            var expectedUser = new User {LastName = lastName};

            _userDataBase.GetUserByLastName(null).ReturnsForAnyArgs(expectedUser);

            //Act
            var result = _userRepository.GetUserByLastName(lastName);

            //Assert
            Assert.AreEqual(expectedUser, result);

            _userDataBase.Received(1).GetUserByLastName(lastName);

            _logger.Received(1).LogInfo(UserRepository.GetUserMessage, Arg.Any<string>());
            _logger.Received(1).LogInfo(UserRepository.UserRecieveMessage, Arg.Any<string>());

            _validator.Received(1).ValidateNotEmptyString(lastName, Arg.Any<string>());
            _validator.Received(1).ValidateNotNull(expectedUser);
        }


        [Test]
        public void Get()
        {
            // _validator.ValidateNotNull(null).Throws<ArgumentException>();
        }
    }
}