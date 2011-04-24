using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoronoiMosaic
{
    public class ProgressReporter
    {
        public delegate void ProgressChangedEventHandler(int progressPercentage);

        public event ProgressChangedEventHandler ProgressChanged;

        // time: component -> milliseconds
        public Dictionary<string, long> TimeReport { get; set; }

        public ProgressReporter()
        {
            TimeReport = new Dictionary<string, long>();
        }

        public void ReportProgress(int progressPercentage)
        {
            if ((progressPercentage < 0) || ( progressPercentage > 100)) {
                return;
            }
            if (ProgressChanged != null)
            {
                ProgressChanged.Invoke(progressPercentage);
            }
        }
    }
}
