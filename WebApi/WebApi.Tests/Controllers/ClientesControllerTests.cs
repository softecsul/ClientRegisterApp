using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers.Tests
{
    /// <summary>
    /// TODO: Implementar
    /// </summary>
    [TestClass()]
    public class ClientesControllerTests
    {

        [TestMethod()]
        public async void GetClienteTest()
        {
            // Arrange
            using (var controller = new ClientesController())
            {
                
                // Act
                var result = await controller.GetCliente(1);

                // Assert
                Assert.IsNotNull(result);
                //Assert.AreEqual(2, result.Result.Count());
                //Assert.AreEqual("value1", result.ElementAt(0));
                //Assert.AreEqual("value2", result.ElementAt(1));
            }
        }

        [TestMethod()]
        public void GetClientesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutClienteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostClienteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteClienteTest()
        {
            Assert.Fail();
        }
    }
}