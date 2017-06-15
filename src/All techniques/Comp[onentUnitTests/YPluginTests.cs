using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bnaya.Samples;
using Moq;

namespace ComponentUnitTests
{
    [TestClass]
    public class YPluginTests
    {
        private readonly Mock<IBar> _barMock = new Mock<IBar>();

        [TestMethod]
        public void YPlugin_InvokeBeepTwice_Test()
        {
            _barMock.Setup(m => m.Read()).Returns("test");
            var p = new YPlugin(_barMock.Object);
            string x = p.Format(1);

            Assert.AreEqual("# test #", x);
        }
    }
}
