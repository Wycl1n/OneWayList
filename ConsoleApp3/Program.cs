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
            List.Add(1);
            List.Add(2);
            List.Show();
            Console.WriteLine(List.firstNode.nextNode.nextNode.data);
            List.Add(3);
            List.Show();
            List.Remove(3);
            List.Show();
            Console.WriteLine(List.Get(0));
            Console.WriteLine(List.Get(1));
        }
    }
}
