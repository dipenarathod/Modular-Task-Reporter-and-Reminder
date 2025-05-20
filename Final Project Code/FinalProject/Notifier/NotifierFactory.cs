using FinalProject.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Notifier
{
    public static class NotifierFactory
    {
        private static String pluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notifier Plugins","Notifier Plugins.json");
        private static String configuredPluginDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Notifier Plugins", "Configured Notifier Plugins.json");
        private static Dictionary<String, String> pluginMap;
        private static Dictionary<string, Dictionary<string, string>> configuredPlugins;
        static NotifierFactory()
        {
            LoadNotifierData();
            LoadConfiguredPlugins();
        }
        public static void LoadNotifierData()
        {
            
            String json = File.ReadAllText(pluginDirectory);
            pluginMap = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
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
        public static List<String> GetAvailableNotifierNames()
        {
            return new List<String>(pluginMap.Keys);
        }

        public static String ConfiguredPluginsDirectory()
        {
            return configuredPluginDirectory;
        }

        public static List<string> GetConfiguredNotifierNames()
        {
            var path = NotifierFactory.ConfiguredPluginsDirectory();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var configs = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
                if (configs == null || configs.Keys.ToList() == null)
                {
                    return new List<string>();
                }
                else
                {
                    return configs.Keys.ToList();
                }
            }
            return new List<string>();
        }

        public static NotifierIF CreateNotifier(String displayName)
        {
            if (pluginMap.TryGetValue(displayName, out string fullClassName))
            {
                Type type = Type.GetType(fullClassName);
                if (type != null)
                {
                    NotifierIF plugin = (NotifierIF)Activator.CreateInstance(type);
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
                else
                {
                    throw new Exception("Type not found for: " + fullClassName);
                }
            }
            else
            {
                throw new Exception("Notifier not found: " + displayName);
            }

            throw new Exception("Notifier "+displayName+" not found or invalid.");
        }
        public static void ReloadPlugins()
        {
            LoadNotifierData();
            LoadConfiguredPlugins();
        }   
    }
}
