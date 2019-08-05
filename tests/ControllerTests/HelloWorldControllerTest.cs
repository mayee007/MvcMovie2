using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie2.tests.ControllerTests 
{
    public class HelloworldControllerTest 
    {
        HelloWorldController controller; 

        public HelloworldControllerTest() 
        {
            controller = new HelloWorldController(); 
        }

        [Fact]
        public void aboutNotNullTest() 
        {
            var result = controller.Index() as ViewResult; 
            Assert.NotNull(result); 
        }

        [Fact]
        public void welcomeTestNotNull() 
        {
            var result = controller.Welcome("mahesh", 4) as ViewResult; 
            Assert.NotNull(result.ViewData["Message"]); 
            Assert.NotNull(result.ViewData["NumTimes"]); 
        }

        [Theory]
        [InlineData("mahesh", 4, "Hello mahesh", 4)]
        [InlineData("mahesh", 0, "Hello mahesh", 0)]
        [InlineData("mahesh", -1, "Hello mahesh", -1)]
        [InlineData("", 0, "Hello ", 0)]
        public void welcomeTest(string name, int num, string expectedName, int expectedNum) 
        {
            var result = controller.Welcome(name,num) as ViewResult; 
            Assert.Equal(expectedName, result.ViewData["Message"]); 
            Assert.Equal(expectedNum,result.ViewData["NumTimes"]); 
        }
    }
}