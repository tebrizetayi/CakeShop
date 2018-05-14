using CakeShop.Net.BS.Implementation;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CakeShop.Net.Test
{
    [TestClass]
    public class UserManagementBsTest
    {
        Mock<AppDbContext> _mockAppDbContext;
        UserManagementBs _userManagementBs;
        Mock<UserManager<IdentityUser>> _userManager;
        Mock<SignInManager<IdentityUser>> _signInManager;
        string usrname;
        string psw;



        [TestCleanup]
        public void TestCleanup()
        {
            Transformation.MapperReset();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //Transformation stuff.
            Transformation.MapperInitialization();
            //Database configuration.
            DbContextOptions<AppDbContext> _options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase("CakeShopeDb", null)
                                .Options;
            var userStore = new Mock<IUserStore<IdentityUser>>();
            _mockAppDbContext = new Mock<AppDbContext>(_options);

            _userManager = new Mock<UserManager<IdentityUser>>(userStore.Object, null, null, null, null, null, null, null, null);
            _signInManager = new Mock<SignInManager<IdentityUser>>(_userManager.Object,
                                            new Mock<IHttpContextAccessor>().Object,
                                            new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                                            new Mock<IOptions<IdentityOptions>>().Object,
                                            new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                                            new Mock<IAuthenticationSchemeProvider>().Object);
            _userManagementBs = new UserManagementBs(_userManager.Object, _signInManager.Object);
            usrname = "user";
            psw = "123";
        }

        [TestMethod]
        public void UserManagerLoginSuccessfully()
        {
            //Arrange
            _userManager.Setup(x => x.FindByNameAsync(usrname)).Returns(new Task<IdentityUser>(() => new IdentityUser()));
            _signInManager.Setup(x => x.PasswordSignInAsync(usrname, psw, false, false)).Returns(new Task<SignInResult>(() => new SignInResult() { }));
            //Act
            var signInResult = _userManagementBs.Login(usrname, psw);
            //Assert
            _userManager.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once, "FindByName in UserManager is not called!");
            _signInManager.Verify(x => x.PasswordSignInAsync(usrname, psw, false, false), Times.Once, "PasswordSignInAsync in SigninManager is not called!");
        }

        [TestMethod]
        public void UserManagerLoginUsernameIsNotCorrect()
        {
            //Arrange
            _userManager.Setup(x => x.FindByNameAsync(usrname)).Returns(() => null);
            _signInManager.Setup(x => x.PasswordSignInAsync(usrname, psw, false, false)).Returns(new Task<SignInResult>(() => new SignInResult() { }));
            //Act
            var signInResult = _userManagementBs.Login(usrname, psw);
            //Assert
            _userManager.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Once, "FindByName in UserManager is not called!");
            _signInManager.Verify(x => x.PasswordSignInAsync(usrname, psw, false, false), Times.Never, "PasswordSignInAsync in SigninManager is  called!");
        }

        [TestMethod]
        public void UserManagerRegisterSuccessfully()
        {
            //Arrange
            var identityUser = new IdentityUser(usrname);
            _userManager.Setup(x => x.CreateAsync(identityUser, psw)).Returns(new Task<IdentityResult>(() => new IdentityResult()));
            //Act
            var signInResult = _userManagementBs.Register(usrname, psw);
            //Assert
            _userManager.Verify(x => x.CreateAsync(It.IsAny<IdentityUser>(), psw), Times.Once, "CreateAsync in UserManager is not called!");
        }
    }
}
