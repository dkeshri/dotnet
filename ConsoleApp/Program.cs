using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Basic;
using ConsoleApp.Basic.Async;
using ConsoleApp.Basic.Generic;
using ConsoleApp.Basic.Linq;
using ConsoleApp.Basic.Temp;
using ConsoleApp.Programming;
using Newtonsoft.Json;

namespace ConsoleApp
{




    class Program
    {

        static void Main(string[] args)
        {
            int[] num = new int[] {1,7,4,7,98,7};
            num = num.OrderBy(x=>x).ToArray();
            foreach(int a in num){
                Console.WriteLine(a);
            }

            // AsyncEx asyncEx = new AsyncEx();
            // asyncEx.run();
            //new StringProgramEx().run();
            //new EventAndDelegateEx().run();
            //new InterViewPractice().run();
        }
    }
}
