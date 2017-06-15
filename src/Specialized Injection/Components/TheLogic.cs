using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Components
{
    // No need for AutoFac reference
    public class TheLogic : ILogic
    {
        public const string CONFIG_KEY = "Logic.Setting";
        private readonly IConfiguration _config;
        private readonly ILogger _logger;

        // Constructor injection (no need for AutoFac reference)
        public TheLogic(
            IConfiguration config,
            ILogger logger)
        {
            _config = config;
            _logger = logger;
            _logger.Log(SeverityLevel.Info, "Created");
        }

        public double Calc(double value)
        {
            _logger.Log(SeverityLevel.Info, "Calculating");
            try
            {
                var factor = _config.Get<FactorSetting>(CONFIG_KEY);
                double result = value * factor.Value;
                _logger.Log(SeverityLevel.Info, $"Calculate result of {value} = {result}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Log(SeverityLevel.Error, $"Fail: {ex}");
                throw;
            }
        }
    }
}
