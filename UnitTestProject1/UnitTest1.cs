using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testResult = new WebApplication1.Services.HackerAPIServices().GetTopTwentyResults();
            
            Assert.IsInstanceOfType(testResult, typeof(Task<HackerAPIModel[]>));
        }
    }
}
