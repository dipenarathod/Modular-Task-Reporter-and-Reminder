using FinalProject.Common;
using FinalProject.Information_Collector;
using FinalProject.Notifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Report
{
    public interface ReportIF : SchedulableIF
    {
       
        List<ReportIF> ToReportList();

        void AddPlugin(InformationCollectorIF plugin);
        void RemovePlugin(InformationCollectorIF plugin);
        List<InformationCollectorIF> GetPlugins();
        void SetPlugins(List<InformationCollectorIF> plugins);
        bool ContainsReport(ReportIF target);
        Task CollectData();

    }
}
