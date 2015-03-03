using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;
using Band.Controllers;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
        public void FirstRealTest()
        {
            var controller = new CheckOutsController();
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result.ViewName);
        }
    }
}
