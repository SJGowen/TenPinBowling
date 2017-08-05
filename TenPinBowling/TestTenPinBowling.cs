using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TenPinBowling
{
    [TestClass]
    public class TestTenPinBowling
    {
        Game game;

        [TestInitialize]
        public void GameStart()
        {
            game = new Game();
        }

        [TestMethod]
        public void TestTwoThrowsNoStrikeOrSpare()
        {
            game.Thrown(5);
            game.Thrown(4);
            Assert.AreEqual(9, game.ScoreForFrame(0));
            Assert.AreEqual(9, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestFourThrowsNoStrikeOrSpare()
        {
            game.Thrown(5);
            game.Thrown(4);
            game.Thrown(7);
            game.Thrown(1);
            Assert.AreEqual(9, game.ScoreForFrame(0));
            Assert.AreEqual(8, game.ScoreForFrame(1));
            Assert.AreEqual(17, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestFourThrowsSpare()
        {
            game.Thrown(5);
            game.Thrown(5);
            game.Thrown(7);
            game.Thrown(2);
            Assert.AreEqual(17, game.ScoreForFrame(0));
            Assert.AreEqual(9, game.ScoreForFrame(1));
            Assert.AreEqual(26, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrowsStrike()
        {
            game.Thrown(10);
            game.Thrown(7);
            game.Thrown(2);
            Assert.AreEqual(19, game.ScoreForFrame(0));
            Assert.AreEqual(9, game.ScoreForFrame(1));
            Assert.AreEqual(28, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrows2Strikes()
        {
            game.Thrown(10);
            game.Thrown(10);
            game.Thrown(7);
            game.Thrown(2);
            Assert.AreEqual(27, game.ScoreForFrame(0));
            Assert.AreEqual(19, game.ScoreForFrame(1));
            Assert.AreEqual(9, game.ScoreForFrame(2));
            Assert.AreEqual(55, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrows3Strikes()
        {
            game.Thrown(10);
            game.Thrown(10);
            game.Thrown(10);
            game.Thrown(7);
            game.Thrown(2);
            Assert.AreEqual(30, game.ScoreForFrame(0));
            Assert.AreEqual(27, game.ScoreForFrame(1));
            Assert.AreEqual(19, game.ScoreForFrame(2));
            Assert.AreEqual(9, game.ScoreForFrame(3));
            Assert.AreEqual(85, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrowsPerfectGame()
        {
            for (var frame = 0; frame < 12; frame++)
            {
                game.Thrown(10);
            }
            for (var frame = 0; frame < 10; frame++)
            {
                Assert.AreEqual(30, game.ScoreForFrame(frame));
            }
            Assert.AreEqual(300, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrowsHeartbreak()
        {
            for (var frame = 0; frame < 11; frame++)
            {
                game.Thrown(10);
            }
            game.Thrown(9);
            for (var frame = 0; frame < 9; frame++)
            {
                Assert.AreEqual(30, game.ScoreForFrame(frame));
            }
            Assert.AreEqual(29, game.ScoreForFrame(9));
            Assert.AreEqual(299, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrowsHeartbreakOneEarly()
        {
            for (var frame = 0; frame < 10; frame++)
            {
                game.Thrown(10);
            }
            game.Thrown(9);
            game.Thrown(1);
            for (var frame = 0; frame < 8; frame++)
            {
                Assert.AreEqual(30, game.ScoreForFrame(frame));
            }
            Assert.AreEqual(29, game.ScoreForFrame(8));
            Assert.AreEqual(20, game.ScoreForFrame(9));
            Assert.AreEqual(289, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }

        [TestMethod]
        public void TestThrowsOneCompleteGame()
        {
            game.Thrown(10);
            game.Thrown(7);
            game.Thrown(3);
            game.Thrown(9);
            game.Thrown(0);
            game.Thrown(10);
            game.Thrown(0);
            game.Thrown(8);
            game.Thrown(8);
            game.Thrown(2);
            game.Thrown(0);
            game.Thrown(6);
            game.Thrown(10);
            game.Thrown(10);
            game.Thrown(10);
            game.Thrown(8);
            game.Thrown(1);
            Assert.AreEqual(20, game.ScoreForFrame(0));
            Assert.AreEqual(19, game.ScoreForFrame(1));
            Assert.AreEqual(9, game.ScoreForFrame(2));
            Assert.AreEqual(18, game.ScoreForFrame(3));
            Assert.AreEqual(8, game.ScoreForFrame(4));
            Assert.AreEqual(10, game.ScoreForFrame(5));
            Assert.AreEqual(6, game.ScoreForFrame(6));
            Assert.AreEqual(30, game.ScoreForFrame(7));
            Assert.AreEqual(28, game.ScoreForFrame(8));
            Assert.AreEqual(19, game.ScoreForFrame(9));
            Assert.AreEqual(167, game.TotalScore());
            Assert.IsTrue(game.ValidateFrames());
        }
    }
}
