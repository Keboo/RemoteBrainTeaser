using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace RemoteBrainTeaser
{
    /*
     * This file should NOT be modified
     */

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TheQuestion()
        {
            var sut = new TestMe();
            int result = sut.GetAnswer();
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void BattleOfWits()
        {
            var sicilianMock = new Mock<ISicilian>();
            var goblet1 = new Goblet();
            var goblet2 = new Goblet();
            sicilianMock.Setup(x => x.SelectGlass(goblet1, goblet2)).Returns(goblet1);
            var sut = new TestMe(sicilianMock.Object);

            Goblet result = sut.Inconceivable(goblet1, goblet2);

            sicilianMock.Verify(x => x.SelectGlass(goblet1, goblet2), Times.Once());
            Assert.AreEqual(goblet2, result);
        }
    }

    public partial class TestMe
    {
        private readonly ISicilian _dependency;

        public TestMe()
        { }

        public int GetAnswer()
        {
            return 0;
        }

        public TestMe(ISicilian dependency)
        {
            _dependency = dependency;
        }

        public Goblet Inconceivable(Goblet first, Goblet second)
        {
           return  _dependency.SelectGlass(first, second);
        }
    }

    public class Goblet { }

    public interface ISicilian
    {
        Goblet SelectGlass(Goblet first, Goblet second);
    }
}
