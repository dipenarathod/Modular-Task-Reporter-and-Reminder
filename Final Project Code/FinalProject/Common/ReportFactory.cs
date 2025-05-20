using FinalProject.Information_Collector;
using FinalProject.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Checked
namespace FinalProject.Common
{
    public static class ReportFactory
    {
        public static ReportIF CreateReport(string reportType, string title, string description,DateTime triggerTime,
                                            RepeatSchedule schedule, List<ReportIF> subReports = null,
                                            List<InformationCollectorIF> sources = null)
        {
            if (reportType.ToLower().Contains("basic"))
            {
                var basic = new BasicReport(title, description, triggerTime, schedule);

                if (sources != null)
                {
                    foreach (var plugin in sources)
                    {
                        basic.AddPlugin(plugin);
                    }
                }

                return basic;
            }
            else if (reportType.ToLower().Contains("composite"))
            {
                var composite = new CompositeReport(title, description, triggerTime, schedule);

                if (subReports != null)
                {
                    foreach (var r in subReports)
                        composite.AddReport(r);
                }
                if (sources != null)
                {
                    foreach (var plugin in sources)
                    {
                        composite.AddPlugin(plugin);
                    }
                }
                return composite;
            }
            else
            {
                throw new Exception("Invalid report String: " + reportType);
            }
        }
    }
}
