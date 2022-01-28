using DesignPrincipal.Basic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Programming
{
    public class StringProgram
    {
        public Dictionary<char,int> OccuranceOfChar(string s)
        {
            s = s.ToLower();
            Dictionary<char, int> counter = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                
                if (counter.ContainsKey(ch))
                {
                    counter[ch]++;
                }
                else
                {
                    counter.Add(ch, 1);
                }

            }
            // Method 1
            // var sortedCounter = counter.OrderBy(x => x.Key).ToList();
            // foreach(KeyValuePair<char,int> kpv in sortedCounter){
            //     Console.WriteLine($"{kpv.Key} occurs: {kpv.Value}");
            // }

            // Method 2 Order the charecters in assending order.
            counter = counter.OrderBy(x => x.Key).ToDictionary(x => x.Key, t => t.Value);
            foreach(KeyValuePair<char,int> kpv in counter){
                Console.WriteLine($"{kpv.Key} occurs: {kpv.Value}");
            }
            return counter;
        }
        public KeyValuePair<char,int> MaxOccuranceChar(string s){
            KeyValuePair<char,int> kp = new KeyValuePair<char, int>();
            Dictionary<char,int> counter = OccuranceOfChar(s);
            kp = counter.OrderByDescending(x => x.Value).FirstOrDefault();
            Console.WriteLine($"Maximum occure char is {kp.Key} and count is : {kp.Value}");
            return kp;
        }
    }
    public class StringProgramEx : IExecute
    {
        public void run()
        {

            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            StringProgram stringProgram = new StringProgram();
            stringProgram.MaxOccuranceChar(input);

        }
    }
}