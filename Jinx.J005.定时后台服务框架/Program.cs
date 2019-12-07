using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Jinx.J005.定时后台服务框架
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceRunner>();

                x.SetDescription("定时后台服务框架描述");
                x.SetDisplayName("定时后台服务框架显示名称");
                x.SetServiceName("定时后台服务框架名称");

                x.EnablePauseAndContinue();
            });
        }
    }
}
