using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinx.J009.桶排序
{
    public class LinkNode
    {
        public int Value { get; set; }
        public LinkNode Next { get; set; }
        public LinkNode() { }
        public LinkNode(int value) { Value = value; }
    }
    class Program
    {
        static int Length = 100000;
        static int Min = 0;
        static int Max = 100000;
        static void Main(string[] args)
        {
            Prepare();
            int[] list = ReadData();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            LinkNode[] sort = new LinkNode[30];
            for (int i = 0; i < list.Length; i++)
            {
                int map = Map(list[i]);
                LinkNode node = new LinkNode(list[i]);
                if (sort[map] == null)
                {
                    sort[map] = new LinkNode() { Next = node };
                }
                else
                {
                    LinkNode head = sort[map];
                    while (head.Next != null && head.Next.Value < node.Value)
                    {
                        head = head.Next;
                    }
                    node.Next = head.Next;
                    head.Next = node;
                }
            }
            int[] list2 = new int[list.Length];
            for (int i = 0, j = 0; i < sort.Length; i++)
            {
                if (sort[i] != null)
                {
                    LinkNode head = sort[i].Next;
                    while (head != null)
                    {
                        list2[j] = head.Value;
                        head = head.Next;
                        j++;
                    }
                }
            }
            WriteData(list2, "桶排序.txt");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            int[] list3 = list;
            for (int i = 0; i < list3.Length - 1; i++)
            {
                for (int j = 0; j < list3.Length - 1 - i; j++)
                {
                    if (list3[j] > list3[j + 1])
                    {
                        int temp = list3[j];
                        list3[j] = list3[j + 1];
                        list3[j + 1] = temp;
                    }
                }
            }
            WriteData(list3, "冒泡排序.txt");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void Prepare()
        {
            int[] list = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                list[i] = new Random(Guid.NewGuid().GetHashCode()).Next(Min, Max);
            }
            StreamWriter sw = new StreamWriter("排序前.txt", false);
            sw.WriteLine(String.Join(" ", list));
            sw.Flush();
            sw.Close();
        }

        static int[] ReadData()
        {
            List<int> list = new List<int>();
            StreamReader sw = new StreamReader("排序前.txt");
            string data = sw.ReadLine();
            sw.Close();
            list = data.Split(' ').Select(p => int.Parse(p)).ToList();
            return list.ToArray();
        }

        static void WriteData(int[] list, string file)
        {
            StreamWriter sw = new StreamWriter(file, false);
            sw.WriteLine(String.Join(" ", list));
            sw.Flush();
            sw.Close();
        }

        static int Map(int value)
        {
            return value * 30 / Length;
        }
    }
}
