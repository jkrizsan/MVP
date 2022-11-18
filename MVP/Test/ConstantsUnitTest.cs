using Data;
using NUnit.Framework;

namespace Tests
{
    public class ConstantsUnitTest
    {
        private const string _testString = "Test";

        [Test]
        public void GetString_OneParam_Ok()
        {
            string format = _testString + " {0}";

            string param = $"{nameof(param)}";

            string result = Constants.GetString(format, param);

            Assert.AreEqual($"{_testString} {param}", result);
        }

        [Test]
        public void GetString_TwoParams_Ok()
        {
            string format = _testString + " {0} and {1}";

            string param1 = $"{nameof(param1)}";
            string param2 = $"{nameof(param2)}";

            string result = Constants.GetString(format, param1, param2);

            Assert.AreEqual($"{_testString} {param1} and {param2}", result);
        }
    }
}
