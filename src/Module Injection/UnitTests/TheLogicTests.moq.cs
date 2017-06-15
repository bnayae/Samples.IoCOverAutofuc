using System;
using Components;
using Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class TheLogic_Moq_Tests
    {
        private Mock<IConfiguration> _configMock = new Mock<IConfiguration>();
        private Mock<ILogger> _loggerMock = new Mock<ILogger>();

        [TestInitialize]
        public void Setup()
        {
            //_repositoryMock.Setup(m => m.LoadFactor("A"))
            _configMock.Setup(m => m.Get<FactorSetting>(TheLogic.CONFIG_KEY))
                           .Returns(() => new FactorSetting { Value = 2 });
        }

        [TestMethod]
        public void Logic_With30_Test()
        {
            // arrange
            var logic = new TheLogic(
                _configMock.Object,
                _loggerMock.Object);

            // act
            double result = logic.Calc(30);

            // assert
            Assert.AreEqual(60, result, "fail to check 30");
            _loggerMock.Verify(m => m.Log(SeverityLevel.Info,
                                            It.IsAny<string>()), Times.AtLeast(1), "Log");
            _loggerMock.Verify(m => m.Log(SeverityLevel.Error,
                                            It.IsAny<string>()), Times.Never(), "Log");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Logic_Throw_Simple_Test()
        {
            // arrange
            var logic = new TheLogic(
                _configMock.Object,
                _loggerMock.Object);
            _configMock.Setup(m => m.Get<FactorSetting>(It.IsAny<string>()))
                        .Throws<ArgumentOutOfRangeException>();

            // act
            logic.Calc(30);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Logic_Throw_Advance_Test()
        {
            // arrange
            var logic = new TheLogic(
                _configMock.Object,
                _loggerMock.Object);
            _configMock.Setup(m => m.Get<FactorSetting>(It.IsAny<string>()))
                        .Throws<ArgumentOutOfRangeException>();

            // act
            try
            {
                double result = logic.Calc(30);
                throw new Exception();
            }
            catch (ArgumentOutOfRangeException)
            {
                // expected
            }

            // assert
            _loggerMock.Verify(m => m.Log(SeverityLevel.Info,
                                            It.IsAny<string>()), Times.AtLeast(1), "Log");
            _loggerMock.Verify(m => m.Log(SeverityLevel.Error,
                                            It.IsAny<string>()), Times.Once(), "Log");
        }

    }
}
