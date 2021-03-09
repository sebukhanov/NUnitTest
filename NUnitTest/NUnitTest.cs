using NUnit.Framework;
using System.Threading;

namespace NUnitTest
{
    public class NUnitTest
    {
        Jenkins jenkins;

        [SetUp]
        public void Setup()
        {
            jenkins = new Jenkins();
        }

        [TearDown]
        public void Teardown()
        { 
        }

        [Test]
        public void Search()
        {
            jenkins.RunJenkinsJob();
            Thread.Sleep(30000);
            Assert.AreEqual(1, 1);
        }
    }
}