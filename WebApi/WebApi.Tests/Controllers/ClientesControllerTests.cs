using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApi.Controllers.Tests
{
    /// <summary>
    /// TODO: Implementar
    /// </summary>
    [TestClass()]
    public class ClientesControllerTests
    {

        //[TestMethod()]
        //public async Task TesteInclusaoCliente()
        //{
        //    // Quando é async, não pode retornar void, tem que ser uma task..
        //    {
        //        var lstCliente = new Models.Cliente();
        //        lstCliente.ID = 10;
        //        lstCliente.Name = "Anderson F da Costa 10";
        //        lstCliente.Address = "Rua Nilo Peçanha, 81";
        //        lstCliente.Phone = "49-3333-7777";

        //        //var resincluirCliente = await ctrCliente.PostCliente(lstCliente);
        //        string Json = JsonConvert.SerializeObject(lstCliente, Formatting.Indented);
        //        var content = new StringContent(Json, Encoding.UTF8, "application/json");
        //        content.Headers.Add("Accept", "application/json");
        //        HttpClient client = new HttpClient();
        //        await client.PostAsync("http://localhost:14622/api/clientes", content);

        //    }
        //}

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

        //[TestMethod()]
        //public void GetClientesTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void PutClienteTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void PostClienteTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteClienteTest()
        //{
        //    Assert.Fail();
        //}
    }
}