using Solutions.Day01;
using Solutions.Day02;

namespace SolutionTests
{
    [TestClass]
    public class Day02SolutionTests
    {
        [TestMethod]
        public void Day02Testers()
        {
            //arrange
            var sut = new Day02Solution();

            //act
            var result = sut.GetRockPaperScissorsResult();

            //assert
            Assert.AreEqual(11767, result);
        }
    }
}