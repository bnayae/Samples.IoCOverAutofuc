using System;
using Components;
using Contracts;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TheLogic_FackItEasy_Tests
    {
        private IConfiguration _config = A.Fake<IConfiguration>();
        private ILogger _logger = A.Fake<ILogger>();

        [TestInitialize]
        public void Setup()
        {
            //_repositoryMock.Setup(m => m.LoadFactor("A"))
            A.CallTo(() => _config.Get<FactorSetting>(TheLogic.CONFIG_KEY))
                            .ReturnsLazily(() => new FactorSetting { Value = 2 });
        }

        [TestMethod]
        public void Logic_With30_Test()
        {
            // arrange
            var logic = new TheLogic(_config, _logger);

            // act
            double result = logic.Calc(30);

            // assert
            Assert.AreEqual(60, result, "fail to check 30");
            A.CallTo(() => _logger.Log(SeverityLevel.Info, A<string>.Ignored))
                .MustHaveHappened(Repeated.AtLeast.Times(1));
            A.CallTo(() => _logger.Log(SeverityLevel.Error, A<string>.Ignored))
                .MustHaveHappened(Repeated.Never);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Logic_Throw_Simple_Test()
        {
            // arrange
            var logic = new TheLogic(_config, _logger);
            A.CallTo(() => _config.Get<FactorSetting>(TheLogic.CONFIG_KEY))
                .Throws<ArgumentOutOfRangeException>();

            // act
            logic.Calc(30);
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Logic_Throw_Advance_Test()
        {
            // arrange
            var logic = new TheLogic(_config, _logger);
            A.CallTo(() => _config.Get<FactorSetting>(TheLogic.CONFIG_KEY))
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
            A.CallTo(() => _logger.Log(SeverityLevel.Info, A<string>.Ignored))
                .MustHaveHappened(Repeated.AtLeast.Times(1));
            A.CallTo(() => _logger.Log(SeverityLevel.Error, A<string>.Ignored))
                .MustHaveHappened(Repeated.AtLeast.Once);
        }

    }
}
