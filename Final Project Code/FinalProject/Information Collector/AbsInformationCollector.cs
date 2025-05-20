using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Checked
namespace FinalProject.Information_Collector
{
    public abstract class AbsInformationCollector: InformationCollectorIF
    {
        [JsonProperty]
        protected String source;
        [JsonProperty]
        String title;
        [JsonProperty]
        String description;
        [JsonProperty]
        protected String ID = "";
        [JsonProperty]
        Dictionary<String, String> requiredParameters = new Dictionary<String, String>();
        [JsonProperty]
        Dictionary<String, String> optionalParameters = new Dictionary<String, String>();
        [JsonProperty]
        Dictionary<String, String> runtimeRequiredParameters=new Dictionary<String, String>();
        [JsonProperty]
        Dictionary<String, String> runtimeOptionalParameters=new Dictionary<String, String>();
        public AbsInformationCollector()
        {
            
        }
        public String GetName()
        {
            return source;
        }
        public String GetSource()
        {
            return source;
        }
        public String GetTitle()
        {
            return title;
        }
        public String GetDescription()
        {
            return description;
        }
        public String GetID()
        {
            return ID;
        }
        public void SetTitle(String title)
        {
            this.title = title;
        }
        public void SetDescription(String description)
        {
            this.description = description;
        }
        public abstract Task CollectInformation();
        public Dictionary<String, String> GetRequiredParameters()
        {
            return requiredParameters;
        }
        public Dictionary<String, String> GetOptionalParameters()
        {
            return optionalParameters;
        }
        public virtual void SetParameters(Dictionary<String, String> required, Dictionary<String, String> optional)
        {
            this.requiredParameters = required;
            this.optionalParameters = optional;
        }

        public Dictionary<String, String> GetRunTimeRequiredParameters()
        {
            return runtimeRequiredParameters;
        }

        public Dictionary<String, String> GetRunTimeOptionalParameters()
        {
            return runtimeOptionalParameters;
        }

        public void SetRunTimeParameters(Dictionary<String, String> requiredParameters, Dictionary<String, String> optionalParameters)
        {
            this.runtimeRequiredParameters = requiredParameters;
            this.runtimeOptionalParameters = optionalParameters;
        }
        public override String ToString()
        {
            return GetName();
        }
    }
}
