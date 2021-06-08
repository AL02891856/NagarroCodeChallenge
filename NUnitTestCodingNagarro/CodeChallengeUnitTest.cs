using NUnit.Framework;

namespace NUnitTestCodingNagarro
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
          
        }

        [TestCase("Smooth", "S3h")]
        [TestCase("Hello World!", "H2o W3d")]
        [TestCase("Hi?everyone I??wish you a fantastic$day", "H0i e6e I0 w2h y1u a0 f5c d1y")]
        public void TestCodeChallenge(string s, string expectedResult)
        {
            var result = CodingTestNagarro.Program.FormatString(s);
            Assert.AreEqual(expectedResult, result);
        }
    }
}