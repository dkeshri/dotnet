using System;
using System.Collections.Generic;
using ConsoleApp.Basic.Generic;
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

            // string[] s = new string[] { "Deepak", "kumar", "keshri" };
            // List<string> m = new List<string>(){
            //     "Pk",
            //     "kumst",
            //     "jkjk"
            // };
            // string a = JsonConvert.SerializeObject(s);
            // Console.WriteLine(a);
            // string[] co = JsonConvert.DeserializeObject<string[]>(a);
            
            // // List<string> listOfString = saperateStringbyComma(combineListOfString(s));
            // foreach (string str in co)
            // {
            //     Console.WriteLine(str);
            // }

            new GenericEx().run();

        }
    }
}
