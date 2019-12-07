using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jinx.J006.多线程调用串行公共方法
{

    public class CommonTask
    {
        public static int Count { get; set; } = 0;

        public static Logger loggerFile = LogManager.GetLogger("多线程调用串行公共方法File");
        public static Logger loggerConsole = LogManager.GetLogger("多线程调用串行公共方法Console");
        public static void Run(string Name)
        {
            lock (loggerFile)
            {
                int wait = new Random(Guid.NewGuid().GetHashCode()).Next(5000, 10000);
                //Console.WriteLine($"CommonTask Run {++Count}");
                //Console.WriteLine($"{Name} Wait {wait}ms");
                loggerFile.Info($"CommonTask Run {++Count}");
                loggerConsole.Info($"CommonTask Run {++Count}");
                loggerFile.Info($"{Name} Wait {wait}ms");
                loggerConsole.Info($"{Name} Wait {wait}ms");
                Thread.Sleep(wait);
            }
        }
    }

    public class TaskOne
    {
        public static void Run()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine($"TaskOne Run {++i}");
                CommonTask.Run("TaskOne");
            }
        }
    }

    public class TaskTwo
    {
        public static void Run()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine($"TaskTwo Run {++i}");
                CommonTask.Run("TaskTwo");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(TaskOne.Run);
            Thread th2 = new Thread(TaskTwo.Run);
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
        }
    }
}
