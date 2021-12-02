using System;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.DataStructure
{
    public static class SearchingAlgo
    {
        // Extension Method.
        public static int BinarySearch(this int[] array, int num)
        {
            int mid, first = 0, last = array.Length - 1;
            while (first <= last)
            {
                mid = first + (last - first) / 2;
                if (array[mid] == num)
                    return mid;
                if (num > array[mid])
                    first = mid + 1;
                else
                    last = mid - 1;
                

            }
            return -1;
        }
    }
    public class SearchingEx : IExecute
    {
        // index start from 0.
        // return the index of find num. if number not found return -1 for that case.

        public void run()
        {
            int[] array = new int[] { 30, 58, 3, 696, 68, 4, -1, 99, 0, 88 };
            int num;
            
            System.Console.WriteLine("\nEnter num to search");
            string s = Console.ReadLine();
            num = int.Parse(s);
            array.bubbelSorting();
            foreach (int a in array)
                System.Console.Write(a + " ");
            System.Console.WriteLine("\nIndex of Find Num is: " +array.BinarySearch(num));
        }
    }
}