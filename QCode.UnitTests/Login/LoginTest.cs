using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QCode.Domain;
using QCode.DomainServices;
using QCode.Persistence;

namespace QCode.UnitTests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Login_Ok_TestMethod()
        {
            //Arrange
            Usuario usuario = new Usuario();
            ILoginService service = new LoginService(new UnitOfWork());

            usuario.UsuarioId = "1010101010";
            usuario.Contrasena = "123";

            //Act
             service.LogIn(usuario);

            //Assert
            Assert.AreEqual(string.Empty, usuario.Contrasena);
            Assert.AreEqual("JUAN PABLO", usuario.Nombre.ToUpper());
        }

        [TestMethod]
        public void Login_Fail_TestMethod()
        {
            //Arrange
            Usuario usuario = new Usuario();
            ILoginService service = new LoginService(new UnitOfWork());

            usuario.UsuarioId = "0101010101";
            usuario.Contrasena = "123";

            //Act
            service.LogIn(usuario);

            //Assert
            Assert.AreEqual("123", usuario.Contrasena);
            Assert.AreEqual(string.Empty, usuario.Nombre.ToUpper());
        }
    }
}
