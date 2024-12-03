
namespace CodeWars
{
    public class Solution
    {
        //main method goes here
        internal static void Main(string[] strings)
        {
            
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test1()
        {
            Solution.Main(new string[] { "Greetings from Javatlacati" });
            Assert.AreEqual(1, 1);
        }
    }
}
