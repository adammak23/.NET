using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using ConnectFour.Fakes;

namespace ConnectFour.Tests
{
    [TestClass()]
    public class CzworkiTests
    {
        [TestMethod()]
        public void FirstTurn_O_Test()
        {
            Czworki czworki = new Czworki();
            var result = czworki.tura(1);
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void SecondTurn_X_Test()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1);
            var result = czworki.tura(1);
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RowTooSmallTest()
        {
            Czworki czworki = new Czworki();
            var result = czworki.tura(0);
            //Assert.AreEqual(0, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RowTooBigTest()
        {
            Czworki czworki = new Czworki();
            var result = czworki.tura(8);
            //Assert.AreEqual(8, result);
        }
        [TestMethod()]
        public void O_WinnerVerticalTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1); czworki.tura(2); czworki.tura(1); czworki.tura(2); czworki.tura(1); czworki.tura(2); czworki.tura(1);
            Assert.AreEqual(4, czworki.CheckingVertical());
        }
        [TestMethod()]
        public void X_WinnerVerticalTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(2); czworki.tura(1); czworki.tura(2); czworki.tura(1); czworki.tura(2); czworki.tura(1); czworki.tura(3); czworki.tura(1);
            Assert.AreEqual(3, czworki.CheckingVertical());
        }
        [TestMethod()]
        public void O_WinnerHorizontalTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1); czworki.tura(7); czworki.tura(2); czworki.tura(7); czworki.tura(3); czworki.tura(7); czworki.tura(4);
            Assert.AreEqual(2, czworki.CheckingHorizontal());
        }
        [TestMethod()]
        public void X_WinnerHorizontalTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(7); czworki.tura(1); czworki.tura(7); czworki.tura(2); czworki.tura(7); czworki.tura(3); czworki.tura(6); czworki.tura(4);
            Assert.AreEqual(1, czworki.CheckingHorizontal());
        }
        [TestMethod()]
        public void InitializedArrayWithout1Test()
        {
            Czworki czworki = new Czworki();
            CollectionAssert.DoesNotContain(czworki.array, 1);
        }
        [TestMethod()]
        public void InitializedArrayWithout2Test()
        {
            Czworki czworki = new Czworki();
            CollectionAssert.DoesNotContain(czworki.array, 2);
        }
        [TestMethod()]
        public void ColumnFullTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1); czworki.tura(1); czworki.tura(1); czworki.tura(1); czworki.tura(1); czworki.tura(1);
            Assert.AreEqual(0, czworki.tura(1));
        }
        [TestMethod()]
        public void O_DiagonalForwardWinnerTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(4); czworki.tura(3); czworki.tura(3); czworki.tura(2); czworki.tura(2); czworki.tura(1); czworki.tura(2); czworki.tura(2); czworki.tura(1); czworki.tura(1); czworki.tura(1);
            Assert.AreEqual(4, czworki.CheckingDiagonal());
        }
        [TestMethod()]
        public void X_DiagonalForwardWinnerTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1); czworki.tura(1); czworki.tura(1); czworki.tura(1); czworki.tura(2); czworki.tura(4); czworki.tura(2); czworki.tura(2); czworki.tura(3); czworki.tura(3);
            Assert.AreEqual(3, czworki.CheckingDiagonal());
        }
        [TestMethod()]
        public void O_DiagonalBackwardWinnerTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(1); czworki.tura(2); czworki.tura(2); czworki.tura(4); czworki.tura(3); czworki.tura(4); czworki.tura(3); czworki.tura(4); czworki.tura(3); czworki.tura(5); czworki.tura(4);
            Assert.AreEqual(2, czworki.CheckingDiagonal());
        }
        [TestMethod()]
        public void X_DiagonalBackwardWinnerTest()
        {
            Czworki czworki = new Czworki();
            czworki.tura(2); czworki.tura(1); czworki.tura(3); czworki.tura(2); czworki.tura(3); czworki.tura(3); czworki.tura(4); czworki.tura(4); czworki.tura(4); czworki.tura(4);
            Assert.AreEqual(1, czworki.CheckingDiagonal());
        }

        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        [TestMethod()]
        [DeploymentItem("array.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
           "|DataDirectory|\\array.xml",
           "Element",
            DataAccessMethod.Sequential)]
        public void ElementsXmlTest() //one at a time
        {
            Czworki czworki = new Czworki();
            var row = TestContext.DataRow;
            var index = row["index"].ToString();
            var _x = row["x"].ToString();
            var _y = row["y"].ToString();

            int index32 = Int32.Parse(index);
            int x32 = Int32.Parse(_x);
            int y32 = Int32.Parse(_y);
            
            czworki.array[x32, y32] = index32;

            CollectionAssert.Contains(czworki.array,1);
        }
        // StringAssert
        [TestMethod()]
        public void SetNicknameTest()
        {
            Czworki czworki = new Czworki();
            czworki.SetPlayersNames("Gracz1", "Gracz2");
            czworki.tura(1);
            StringAssert.StartsWith(czworki.actualPlayer, "Gracz1");
        }

        // stub     
        [TestMethod()]
        public void LockPlayerTurnTest()
        {
            bool wasValidationCalled = false;
            ICzworki stubCzworki = new StubICzworki()
            {
                TuraInt32 = (x) =>
                {
                    return 2;
                }
            };
            stubCzworki.tura(1);
            Assert.AreEqual(2,stubCzworki.tura(1));
        }
        /*shim

        [TestMethod()]
        public void PlayTest()
        {
            using (ShimsContext.Create())
            {
                Czworki czworki = new Czworki();
                DateTime dataTimeFixed = new DateTime();
                var myInstance = new ShimCzworki { GetCurrentDate = () => dataTimeFixed };
                int myInstancedataDateTime = myInstance.Instance.GetCurrentDate();
                Assert.AreEqual(dataTimeFixed, myInstancedataDateTime);
            }
        }
        */
    }
}