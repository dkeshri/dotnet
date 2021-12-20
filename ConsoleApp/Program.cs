using System;
using System.Collections.Generic;
using ConsoleApp.Basic.Generic;
using ConsoleApp.Basic.Linq;
using ConsoleApp.Programming;
using Newtonsoft.Json;

namespace ConsoleApp
{




    class Program
    {

        public static string combineListOfString(string[] listString)
        {
            string aString = "";

            for (int i = 0; i < listString.Length; i++)
            {
                if (i <= listString.Length - 2)
                    aString = aString + listString[i];
                else
                    aString = aString + listString[i];
            }

            return aString;
        }

        public static List<string> saperateStringbyComma(string s)
        {
            int lastPosOfCommma = 0;
            Console.WriteLine(s);
            List<string> ListOfString = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {


                if (s[i] == ',')
                {
                    string tempString = "";
                    for (int j = lastPosOfCommma; j < i; j++)
                    {
                        tempString = tempString + s[j];

                    }
                    ListOfString.Add(tempString);
                    lastPosOfCommma = i + 1;

                }

            }
            return ListOfString;
        }
        static void Main(string[] args)
        {
            new ProgramEx().run();
        }
    }
}
