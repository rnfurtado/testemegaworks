using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test
{
    public class ContaControllerTest
    {
        [Test]
        public async Task Get_WhenCalled_ReturnNotFound()
        {
            service = new Mock<IService>();
            controller = new MyController(service.Object);

            service.Setup(service => service.GetAsync(1)).ReturnsAsync((MyType)null);

            var result = await controller.Get(1);

            Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
        }
    }
}
