using System;
using System.Globalization;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp3;
using static ConsoleApp3.OneWayList;

namespace ВМ
{
    class Program    
    {        
        private static void Main()
        {
            OneWayList List = new OneWayList();
            List.Add("login", "password");
            (string, string) a = List.Get(1);
            Console.WriteLine(a.Item1 + "| " + a.Item2);
            Console.WriteLine(List.Check("login", "password"));
        }
    }
}
