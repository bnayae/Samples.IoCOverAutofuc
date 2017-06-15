using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bnaya.Samples;
using Moq;

namespace Comp_onentUnitTests
{
    [TestClass]
    public class NPluginTests
    {
        private readonly Mock<IBeep> _beepMock = new Mock<IBeep>();

        [TestMethod]
        public void NPlugin_InvokeBeepTwice_Test()
        {
            var p = new NPlugin(new[] { _beepMock.Object, _beepMock.Object });
            string x = p.Format(1);

            _beepMock.Verify(m => m.Beep(), Times.Exactly(2));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NPlugin_Invoke_Throw_WhenMissingDependencies_Test()
        {
            var p = new NPlugin(null);
            string x = p.Format(1);

            _beepMock.Verify(m => m.Beep(), Times.Exactly(2));
        }
    }
}
