﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        //[Test]
        //public void TestOneThrow()
        //{
        //    Game game = new Game();
        //    game.Add(5);
        //    Assert.AreEqual(5, game.Score);
        //    Assert.AreEqual(1, game.CurrentFrame);
        //}

        [Test]
        public void TestTwoThrowsNoMark()
        {
            Game game = new Game();
            game.Add(5);
            game.Add(4);
            Assert.AreEqual(9, game.Score);
            Assert.AreEqual(2, game.CurrentFrame);
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            Game game = new Game();
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(9, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
            Assert.AreEqual(3, game.CurrentFrame);
        }

        [Test]
        public void TestSimpleSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.AreEqual(13, game.ScoreForFrame(1));
            Assert.AreEqual(2, game.CurrentFrame);
        }

        [Test]
        public void TestSimpleFrameAfterSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.AreEqual(13, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
            Assert.AreEqual(18, game.Score);
            Assert.AreEqual(3, game.CurrentFrame);
        }

        [Test]
        public void TestSimpleStrike()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.AreEqual(19, game.ScoreForFrame(1));
            Assert.AreEqual(28, game.Score);
            Assert.AreEqual(3, game.CurrentFrame);
        }

        [Test]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; i++ )
            {
                game.Add(10);
            }

            Assert.AreEqual(300, game.Score);
            Assert.AreEqual(11, game.CurrentFrame);
        }

        [Test]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++ )
            {
                game.Add(0);
                game.Add(0);
            }

            game.Add(2);
            game.Add(8);        // 10th frame spare
            game.Add(10);
            Assert.AreEqual(20, game.Score);
        }

        [Test]
        public void TestSampleGame()
        {
            game.Add(1);
            game.Add(4);
            game.Add(4);
            game.Add(5);
            game.Add(6);
            game.Add(4);
            game.Add(5);
            game.Add(5);
            game.Add(10);
            game.Add(0);
            game.Add(1);
            game.Add(7);
            game.Add(3);
            game.Add(6);
            game.Add(4);
            game.Add(10);
            game.Add(2);
            game.Add(8);
            game.Add(6);
            Assert.AreEqual(133, game.Score);
        }

        [Test]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
                game.Add(10);
            game.Add(9);
            Assert.AreEqual(299, game.Score);
        }
    }
}
