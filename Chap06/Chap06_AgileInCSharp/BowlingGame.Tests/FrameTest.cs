using NUnit.Framework;
using BowlingGame;


namespace BowlingGame.Tests
{
    [TestFixture]
    public class FrameTest
    {
        [Test]
        public void TestScoreNoThrows()
        {
            Frame f = new Frame();
            Assert.AreEqual(0, f.Score);
        }

        [Test]
        public void TestAddOneThrow()
        {
            Frame f = new Frame();
            f.Add(5);
            Assert.AreEqual(5, f.Score);
        }
    }
}
