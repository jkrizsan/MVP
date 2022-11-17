using Data;
using NUnit.Framework;

namespace Tests
{
    public class ConstantsUnitTest
    {
        [Test]
        public void GetString_OneParam_Ok()
        {
            string format = "Test {0}";

            string param = $"{nameof(param)}";

            string result = Constants.GetString(format, param);

            Assert.AreEqual($"Test {param}", result);
        }

        [Test]
        public void GetString_TwoParams_Ok()
        {
            string format = "Test {0} and {1}";

            string param1 = $"{nameof(param1)}";
            string param2 = $"{nameof(param2)}";

            string result = Constants.GetString(format, param1, param2);

            Assert.AreEqual($"Test {param1} and {param2}", result);
        }
    }
}
