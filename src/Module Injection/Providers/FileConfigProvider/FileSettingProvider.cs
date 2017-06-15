using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Newtonsoft.Json;

namespace FileConfigProvider
{
    public class FileSettingProvider : IConfiguration
    {
        private readonly string _configFolder = "Configuration";

        public FileSettingProvider(string configFolder, IConfigMode mode)
        {
            if (mode.IsDebug)
                _configFolder = $"{configFolder}_Debug";
            else
                _configFolder = configFolder;
            if (!Directory.Exists(_configFolder))
                Directory.CreateDirectory(_configFolder);
        }

        public T Get<T>(string key)
            where T : new()
        {
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
    }
}
