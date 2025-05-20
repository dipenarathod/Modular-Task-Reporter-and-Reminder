using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Common
{
    public static class ExternalReminderFactory
    {
        private static Dictionary<string, string> pluginMap;
        private static Dictionary<string, Dictionary<string, string>> configuredPlugins;
        private static readonly string pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External Reminder Plugins", "External Reminder Plugins.json");
        private static readonly string configuredPluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "External Reminder Plugins", "Configured External Reminder Plugins.json");

        static ExternalReminderFactory()
        {
            LoadPluginData();
            LoadConfiguredPlugins();
        }

        public static string ConfiguredPluginsDirectory()
        {
            return configuredPluginDirectory;
        }

        private static void LoadPluginData()
        {
            string jsonPath = pluginDirectory;

            if (!File.Exists(jsonPath))
            {
                throw new Exception("External Reminder plugin information file not found: " + jsonPath);
            }

            string json = File.ReadAllText(jsonPath);
            if(JsonConvert.DeserializeObject<Dictionary<string, string>>(json) == null)
            {
                pluginMap = new Dictionary<string, string>();
            }
            else
            {
                pluginMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
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

        public static ExternalReminderIF CreatePlugin(string displayName)
        {
            if (!pluginMap.TryGetValue(displayName, out string fullClassName))
                throw new Exception("External Reminder plugin not found: " + displayName);

            Type type = Type.GetType(fullClassName);
            if (type == null)
                throw new Exception("Could not load type: " +fullClassName + " for plugin: "+displayName);

            var plugin = (ExternalReminderIF)Activator.CreateInstance(type);

            if (configuredPlugins.ContainsKey(displayName))
            {
                var config = configuredPlugins[displayName];

                var requiredKeys = plugin.GetRequiredParameters().Keys;
                var optionalKeys = plugin.GetOptionalParameters().Keys;

                var required = new Dictionary<string, string>();
                var optional = new Dictionary<string, string>();

                foreach (var kv in config)
                {
                    if (requiredKeys.Contains(kv.Key))
                        required[kv.Key] = kv.Value;
                    else if (optionalKeys.Contains(kv.Key))
                        optional[kv.Key] = kv.Value;
                }

                plugin.SetParameters(required, optional);
            }

            return plugin;
        }

        public static void ReloadPlugins()
        {
            LoadPluginData();
            LoadConfiguredPlugins();
        }
    }
}
