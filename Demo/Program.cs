using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        static void test()
        {
            JsonConfig.JsonConfig cfg = new JsonConfig.JsonConfig("..\\config.json");
            dynamic aaa = cfg.GetProperty("AAA");
            Console.WriteLine(aaa.Name);
            Console.ReadLine();
            aaa.Name = "Andy";
            aaa.Addr = "BBB";
            aaa.C = "CCC";
            aaa.array = new object[] { "arr", 333, DateTime.Now };
            cfg.Save();
        }
    }
}
