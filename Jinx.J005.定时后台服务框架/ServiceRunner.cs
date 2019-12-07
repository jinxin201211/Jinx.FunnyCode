using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Jinx.J005.定时后台服务框架.Jobs;

namespace Jinx.J005.定时后台服务框架
{
    public sealed class ServiceRunner : ServiceControl, ServiceSuspend
    {
        private readonly IScheduler scheduler;

        public ServiceRunner()
        {
            ISchedulerFactory factory;

            //创建一个调度器
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            {
                //创建一个任务
                IJobDetail jobQuartzTest = JobBuilder.Create<QuartzTestJobOne>().WithIdentity("QuartzTestJobOne", "MainGroup").Build();
                //创建一个触发器
                ITrigger triggerQuartzTest = TriggerBuilder.Create()
                  .WithIdentity("QuartzTestJobOneTrigger", "MainGroup")
                  .WithCronSchedule("0/10 * * * * ?")    //1分钟执行一次
                  .Build();
                //将任务与触发器添加到调度器中
                scheduler.ScheduleJob(jobQuartzTest, triggerQuartzTest);
            }

            {
                //创建一个任务
                IJobDetail jobQuartzTest = JobBuilder.Create<QuartzTestJobTwo>().WithIdentity("QuartzTestJobTwo", "MainGroup").Build();
                //创建一个触发器
                ITrigger triggerQuartzTest = TriggerBuilder.Create()
                  .WithIdentity("QuartzTestJobTwoTrigger", "MainGroup")
                  .WithCronSchedule("0/10 * * * * ?")    //1分钟执行一次
                  .Build();
                //将任务与触发器添加到调度器中
                scheduler.ScheduleJob(jobQuartzTest, triggerQuartzTest);
            }

            scheduler.Start();//开始执行
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown(false);
            return true;
        }

        public bool Continue(HostControl hostControl)
        {
            scheduler.ResumeAll();
            return true;
        }

        public bool Pause(HostControl hostControl)
        {
            scheduler.PauseAll();
            return true;
        }
    }
}
