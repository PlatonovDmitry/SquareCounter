namespace SquareCounterTests
{
    [TestClass]
    public class SquareCounterTest
    {
        [TestMethod]
        public void TriangleSquareCount1()
        {
            var counter = new SquareCounter.SquareCounter();
            var result = counter.TriangleSquareCount(5, 3, 4);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void IsTriangleNormal1()
        {
            var counter = new SquareCounter.SquareCounter();
            var result = counter.IsTriangleNormal(5, 3, 4);
            Assert.IsTrue(result);
        }
    }
}