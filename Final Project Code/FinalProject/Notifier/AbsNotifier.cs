using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Checked
namespace FinalProject.Notifier
{
    public abstract class AbsNotifier:NotifierIF
    {
        String name="Blank";
        String title="Title to be set";
        String content="Content to be set";
        Dictionary<String, String> runtimeRequiredParameters;
        Dictionary<String, String> runtimeOptionalParameters;
        Dictionary<String, String> requiredParameters;
        Dictionary<String, String> optionalParameters;
        public AbsNotifier(String name)
        {
            this.name = name;
            requiredParameters = new Dictionary<String, String>();
            optionalParameters = new Dictionary<String, String>();
            runtimeRequiredParameters = new Dictionary<String, String>();
            runtimeOptionalParameters = new Dictionary<String, String>();
        }
        public virtual String GetName()
        {
            return name;
        }
        public virtual String GetTitle()
        {
            return title;
        }
        public virtual String GetContent()
        {
            return content;
        }
        public virtual Dictionary<String, String> GetRequiredParameters()
        {
            return requiredParameters;
        }
        public virtual Dictionary<String, String> GetOptionalParameters()
        {
            return optionalParameters;
        }
        public virtual void SetParameters(Dictionary<String, String> requiredParameters, Dictionary<String, String> optionalParameters)
        {
            this.requiredParameters = requiredParameters;
            this.optionalParameters = optionalParameters;
        }
        public virtual void SetTitle(String title)
        {
            this.title = title;
        }
        public virtual void SetContent(String content)
        {
            this.content = content;
        }
        public abstract Task SendNotification();

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
        public override string ToString()
        {
            return name;
        }
    }
}
