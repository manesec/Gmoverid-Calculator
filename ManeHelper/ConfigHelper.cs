using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManeHelper
{
    public class ConfigHelper
    {
        
        public ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
        public Configuration configFile = null;
        public KeyValueConfigurationCollection settings = null;

        public void LoadConfig(string ConfigFile)
        {
            try
            {
                configMap.ExeConfigFilename = ConfigFile;
                configFile = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                settings = configFile.AppSettings.Settings;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error To open config file");
            }
        }

        public void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        public string GetValue(string key)
        {
            try
            {
               return configFile.AppSettings.Settings[key].Value; 
            }
            catch
            {
                return "null";
            }
        }

    }
}
