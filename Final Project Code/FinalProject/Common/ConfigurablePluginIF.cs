using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Checked
namespace FinalProject.Common
{
    public interface ConfigurablePluginIF
    {
        String GetName();
        String ToString();
        Dictionary<String,String> GetRunTimeRequiredParameters();
        Dictionary<String, String> GetRunTimeOptionalParameters();
        void SetRunTimeParameters(Dictionary<String, String> requiredParameters, Dictionary<String, String> optionalParameters);
        Dictionary<String, String> GetRequiredParameters();
        Dictionary<String, String> GetOptionalParameters();
        void SetParameters(Dictionary<String, String> requiredParameters, Dictionary<String, String> optionalParameters);

    }
}
