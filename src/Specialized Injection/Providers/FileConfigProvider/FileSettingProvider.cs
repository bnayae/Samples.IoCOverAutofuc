using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Autofac.Features.Indexed;
using Contracts;
using Newtonsoft.Json;

namespace FileConfigProvider
{
    public class FileSettingProvider : IConfiguration
    {
        private readonly string _configFolder;
        private readonly ILoggerProvider _logger;

        public FileSettingProvider(
            IConfigMode cfgMode,
            // Avoid circular dependencies (used specialized logger)
            [KeyFilter("Primal")]ILoggerProvider logger,
            // select the implementation according to the ConfigMode
            IIndex<ConfigModes, IFolderSelector> configFolderSelector)
        {
            _logger = logger;

            var mode = cfgMode.Mode;
            var selection = configFolderSelector[mode];
            _configFolder = selection.Folder;
            if (!Directory.Exists(_configFolder))
                Directory.CreateDirectory(_configFolder);
        }

        public T Get<T>(string key)
            where T : new()
        {
            try
            {
                var log = new LogMessage(SeverityLevel.Info, $"Get setting for {key}");
                _logger?.Log(log);
                string path = Path.Combine(_configFolder, $"{key}.json");
                T result;
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    result = JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    result = new T();
                    string json = JsonConvert.SerializeObject(result);
                    File.WriteAllText(path, json);
                }
                return result;
            }
            catch (Exception ex)
            {
                var log = new LogMessage(SeverityLevel.Error, ex.ToString());
                _logger?.Log(log);
                throw;
            }
        }
    }
}
