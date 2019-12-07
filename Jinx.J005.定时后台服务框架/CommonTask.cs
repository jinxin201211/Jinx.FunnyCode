using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jinx.J005.定时后台服务框架
{
    public class CommonTask
    {
        public static int Count { get; set; } = 0;

        public static Logger loggerFile = LogManager.GetLogger("定时后台服务框架File");
        public static Logger loggerConsole = LogManager.GetLogger("定时后台服务框架Console");
        public static void Run(string Name)
        {
            lock (loggerFile)
            {
                int wait = new Random(Guid.NewGuid().GetHashCode()).Next(5000, 10000);
                loggerFile.Info($"CommonTask Run {++Count}");
                loggerConsole.Info($"CommonTask Run {++Count}");
                loggerFile.Info($"{Name} Wait {wait}ms");
                loggerConsole.Info($"{Name} Wait {wait}ms");
                Thread.Sleep(wait);
            }
        }
    }
}
