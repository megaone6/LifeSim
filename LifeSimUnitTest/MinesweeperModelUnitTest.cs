using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeSim.MSModel;
using System;

namespace LifeSimUnitTest
{
    [TestClass]
    public class MinesweeperModelUnitTest
    {

        private MinesweeperModel msmodel;
        private Random rnd;
        int fieldNum;
        int initialFieldNum;
        int x;
        int y;

        [TestInitialize]
        public void Initialize()
        {
            msmodel = new MinesweeperModel();
            msmodel.GameOverEvent += new EventHandler<EventArgs>(Model_GameOverEvent);
            msmodel.GameWonEvent += new EventHandler<EventArgs>(Model_GameWonEvent);
            rnd = new Random();
        }

        [TestMethod]
        public void NewGameTest()
        {
            fieldNum = rnd.Next(0, 64);
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            Assert.IsFalse(msmodel.MineField[x, y].Mine);
            Assert.IsFalse(msmodel.MineField[x, y].Marked);
            Assert.IsTrue(msmodel.MineField[x, y].Revealed);
            Assert.AreEqual(msmodel.MineField[x, y].MinesInProximity, 0);
        }

        [TestMethod]
        public void ReconTestWithoutMine()
        {
            int initialFieldNum;
            fieldNum = rnd.Next(0, 64);
            initialFieldNum = fieldNum;
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            do
            {
                fieldNum = rnd.Next(0, 64);
                x = fieldNum / 8;
                y = fieldNum % 8;
            } while (fieldNum == initialFieldNum || msmodel.MineField[x,y].Mine);
            msmodel.recon(fieldNum);
            Assert.IsTrue(msmodel.MineField[x, y].Revealed);
            Assert.IsFalse(msmodel.MineField[x, y].Mine);
            Assert.IsFalse(msmodel.MineField[x, y].Marked);
        }

        [TestMethod]
        public void ReconTestWithMine()
        {
            fieldNum = rnd.Next(0, 64);
            initialFieldNum = fieldNum;
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            do
            {
                fieldNum = rnd.Next(0, 64);
                x = fieldNum / 8;
                y = fieldNum % 8;
            } while (fieldNum == initialFieldNum || !msmodel.MineField[x, y].Mine);
            msmodel.recon(fieldNum);
            Assert.IsTrue(msmodel.MineField[x, y].Revealed);
            Assert.IsTrue(msmodel.MineField[x, y].Mine);
            Assert.IsFalse(msmodel.MineField[x, y].Marked);
        }

        [TestMethod]
        public void MarkTestOnUnrevealed()
        {
            fieldNum = rnd.Next(0, 64);
            initialFieldNum = fieldNum;
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            do
            {
                fieldNum = rnd.Next(0, 64);
                x = fieldNum / 8;
                y = fieldNum % 8;
            } while (fieldNum == initialFieldNum || msmodel.MineField[x, y].Revealed);
            msmodel.mark(fieldNum);
            Assert.IsFalse(msmodel.MineField[x, y].Revealed);
            Assert.IsTrue(msmodel.MineField[x, y].Marked);
        }

        [TestMethod]
        public void MarkTestOnRevealed()
        {
            fieldNum = rnd.Next(0, 64);
            initialFieldNum = fieldNum;
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            do
            {
                fieldNum = rnd.Next(0, 64);
                x = fieldNum / 8;
                y = fieldNum % 8;
            } while (fieldNum == initialFieldNum || !msmodel.MineField[x, y].Revealed);
            msmodel.mark(fieldNum);
            Assert.IsTrue(msmodel.MineField[x, y].Revealed);
            Assert.IsFalse(msmodel.MineField[x, y].Marked);
        }

        [TestMethod]
        public void WinTest()
        {
            fieldNum = rnd.Next(0, 64);
            initialFieldNum = fieldNum;
            x = fieldNum / 8;
            y = fieldNum % 8;
            msmodel.newGame(fieldNum);
            for (int i = 0; i < 15; i++)
            {
                do
                {
                    fieldNum = rnd.Next(0, 64);
                    x = fieldNum / 8;
                    y = fieldNum % 8;
                } while (fieldNum == initialFieldNum || !msmodel.MineField[x, y].Mine);
                msmodel.mark(fieldNum);
            }
        }

        private void Model_GameOverEvent(object sender, EventArgs e)
        {
            Assert.IsTrue(msmodel.GameOver);
        }

        private void Model_GameWonEvent(object sender, EventArgs e)
        {
            Assert.IsTrue(msmodel.GameOver);
        }
    }
}
