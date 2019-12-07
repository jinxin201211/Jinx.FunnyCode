using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jinx.J008.让List自定义排序规则
{
    /// <summary>
    /// 人物类
    /// </summary>
    public class Person
    {
        public string Name;
        public int Age;
        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age;
        }
    }

    /// <summary>
    /// 比较人物类实例大小，实现接口IComparer
    /// </summary>
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            //TODO：Person类实例X与Y的比较规则
            //按姓名由小到大排列，姓名相同的人年龄大的在前
            {
                int temp = string.Compare(x.Name, y.Name);
                if (temp > 0) return -1;
                else if (temp < 0) return 1;

                if (x.Age > y.Age) return 1;
                if (x.Age < y.Age) return -1;
            }

            return 0;
        }
    }
    public class Class1
    {
        public static void MySort()
        {
            List<Person> a = new List<Person>();

            a.Add(new Person() { Name = "Tsybius", Age = 23 });
            a.Add(new Person() { Name = "Galatea", Age = 21 });
            a.Add(new Person() { Name = "Lucius", Age = 22 });
            a.Add(new Person() { Name = "Septimus", Age = 22 });
            a.Add(new Person() { Name = "Octavius", Age = 22 });
            a.Add(new Person() { Name = "Lucius", Age = 24 });

            //输出a中全部元素
            Console.WriteLine("排序前");
            foreach (var v in a)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine("-");

            //对a进行排序
            a.Sort(new PersonComparer());

            //输出a中全部元素
            Console.WriteLine("排序后");
            foreach (var v in a)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine("-");

            Console.ReadLine();
        }
    }
}
