using NUnit.Framework;

namespace seleniumlearning
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("this is test 1");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("this is test 1");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("this is test 2");
        }
        [TearDown]
        public void ClosedBrowser()
        {
            TestContext.Progress.WriteLine("this is tear down");
        }
     

    }

}