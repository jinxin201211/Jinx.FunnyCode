using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinx.J005.定时后台服务框架.Jobs
{
    public class QuartzTestJobTwo : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine($"QuartzTestJobTwo Run {++i}");
                CommonTask.Run("QuartzTestJobTwo");
            }
        }
    }
}
