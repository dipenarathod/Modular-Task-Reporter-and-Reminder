using FinalProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Information_Collector
{
    public interface InformationCollectorIF:ConfigurablePluginIF
    {
        string GetSource(); //"OpenWeatherMap"
        string GetTitle(); //Title for notification/email section
        string GetDescription(); //Content that will be included in the report
        String GetID(); //Unique identifier for the information collector
        Task CollectInformation();
        void SetTitle(string title);

        void SetDescription(string description);    
    }
}
