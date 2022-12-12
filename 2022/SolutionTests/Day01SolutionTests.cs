using Solutions.Day01;

namespace SolutionTests
{
    [TestClass]
    public class Day01SolutionTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var sut = new Day01Solution();

            //act
            var result = sut.GetTotalCalories();

            //assert
            Assert.IsTrue(result > 0);
        }
    }
}