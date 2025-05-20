using FinalProject.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject
{
    public abstract class AbsExternalReminder:ExternalReminderIF
    {
        [JsonProperty]
        protected String source;
        [JsonProperty]
        Dictionary<string, string> requiredParameters = new Dictionary<string, string>();
        [JsonProperty]
        Dictionary<string, string> optionalParameters = new Dictionary<string, string>();
        [JsonProperty]
        Dictionary<String, String> runtimeRequiredParameters = new Dictionary<string, string>();
        [JsonProperty]
        Dictionary<String, String> runtimeOptionalParameters = new Dictionary<string, string>();

        ExternalReminderManagerIF externalReminderManagerIF = null;
        public AbsExternalReminder(String source)
        {
            this.source = source;
        }

        public string GetName()
        {
            return source;
        }

        public string GetSource()
        {
            return source;
        }

        public Dictionary<string, string> GetRequiredParameters()
        {
            return requiredParameters;
        }
        public Dictionary<string, string> GetOptionalParameters()
        {
            return optionalParameters;
        }
        public virtual void SetParameters(Dictionary<string, string> required, Dictionary<string, string> optional)
        {
            this.requiredParameters = required;
            this.optionalParameters = optional;
        }

        public Dictionary<string, string> GetRunTimeRequiredParameters()
        {
            return runtimeRequiredParameters;
        }

        public Dictionary<string, string> GetRunTimeOptionalParameters()
        {
            return runtimeOptionalParameters;
        }

        public void SetRunTimeParameters(Dictionary<string, string> requiredParameters, Dictionary<string, string> optionalParameters)
        {
            this.runtimeRequiredParameters = requiredParameters;
            this.runtimeOptionalParameters = optionalParameters;
        }
        public void SetExternalReminderManager(ExternalReminderManagerIF externalReminderManager)
        {
            this.externalReminderManagerIF = externalReminderManager;
        }
        public ExternalReminderManagerIF GetExternalReminderManager()
        {
            return externalReminderManagerIF;
        }
        public abstract Task Sync();
        public abstract List<ReminderIF> ToReminderList();
    }
}
