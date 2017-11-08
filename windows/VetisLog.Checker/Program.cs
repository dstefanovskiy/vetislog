using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace VetisLog.Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();
            try
            {
                var vetisLog = new VetisLog();
                vetisLog.Ping();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
