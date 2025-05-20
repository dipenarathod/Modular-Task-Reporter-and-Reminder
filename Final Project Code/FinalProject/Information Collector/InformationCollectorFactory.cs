using FinalProject.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Information_Collector
{
    public static class InformationCollectorFactory
    {
        private static Dictionary<string, string> pluginMap;
        private static Dictionary<string, Dictionary<string, string>> configuredPlugins;
        private static String pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Information Collector Plugins", "Information Collector Plugins.json");
        private static String configuredPluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Information Collector Plugins", "Configured Information Collector Plugins.json");

        static InformationCollectorFactory()
        {
            LoadPluginData();
            LoadConfiguredPlugins();
        }
        
        public static String ConfiguredPluginsDirectory()
        {
            return configuredPluginDirectory;
        }
        private static void LoadPluginData()
        {
            string jsonPath = pluginDirectory;

            if (!File.Exists(jsonPath))
            {
                throw new Exception("Plugin information file not found: " + jsonPath);
            }

            string json = File.ReadAllText(jsonPath);
            pluginMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private static void LoadConfiguredPlugins()
        {
            string jsonPath = configuredPluginDirectory;

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                configuredPlugins = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
            }
            else
            {
                configuredPlugins = new Dictionary<string, Dictionary<string, string>>();
            }
        }

        public static List<string> GetAvailablePluginNames()
        {
            return pluginMap.Keys.ToList();
        }

        public static List<string> GetConfiguredPluginNames()
        {
            return configuredPlugins.Keys.ToList();
        }

        public static InformationCollectorIF CreatePlugin(string displayName)
        {
            if (!pluginMap.TryGetValue(displayName, out string fullClassName))
            {
                throw new Exception("Plugin not found: " + displayName);
            }

            Type type = Type.GetType(fullClassName);

            var plugin = (InformationCollectorIF)Activator.CreateInstance(type);

            if (configuredPlugins.ContainsKey(displayName) && plugin is ConfigurablePluginIF configurable)
            {
                var config = configuredPlugins[displayName];

                var requiredKeys = configurable.GetRequiredParameters().Keys;
                var optionalKeys = configurable.GetOptionalParameters().Keys;

                var required = new Dictionary<string, string>();
                var optional = new Dictionary<string, string>();

                foreach (var kv in config)
                {
                    if (requiredKeys.Contains(kv.Key))
                        required[kv.Key] = kv.Value;
                    else if (optionalKeys.Contains(kv.Key))
                        optional[kv.Key] = kv.Value;
                }

                configurable.SetParameters(required, optional);
            }

            return plugin;
        }

        public static void ReloadPlugins()
        {
            LoadPluginData();
            LoadConfiguredPlugins();
        }

        public static Dictionary<string, string> GetConfiguration(string pluginName)
        {
            if (configuredPlugins.ContainsKey(pluginName))
            {
                return configuredPlugins[pluginName];
            }
            return new Dictionary<string, string>();
        }
    }

}
