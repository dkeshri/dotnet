using System;
using System.Collections.Generic;
using DesignPrincipal.Basic.Interface;

namespace ConsoleApp.DataStructure{
    public static class Sorting{
        public static void SelectionSorting(this int[] array){
            int pos,temp;
            for(int i=0;i<array.Length-1;i++){
                pos = i;
                for(int j=i+1;j<array.Length;j++){
                    if(array[j]<array[pos])
                        pos = j;
                }
                temp = array[pos];
                array[pos] = array[i];
                array[i] = temp;
            }
        }
        public static void bubbelSorting(this int[] array){
            for(int i=0;i<array.Length-1;i++){
                for(int j=0;j<array.Length-i-1;j++){
                    if(array[j]>array[j+1]){
                        int temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }
        }
        public static void InsertionSort(this int[] array){

        }
        public static void CustomSort(this int[] arr)
        {
            //int[] a = new int[] { 3, 1, 3, 2, 1, 3, 2, 1 };

            // array always have number 1 to 3.

            // this algorithms made in interview.
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (d.ContainsKey(arr[i]))
                    d[arr[i]]++;
                else
                    d.Add(arr[i], 1);
            }

            for (int i = 1; i <= 3; i++)
            {
                if (d.ContainsKey(i))
                    for (int j = 1; j <= d[i]; j++)
                        Console.Write(i + " ");

            }

        }
    }
    public class SortingEx : IExecute
    {
        // soring in ascending order.
        
        public void run()
        {
            int[] array = new int[]{30,58,3,696,68,4,-1,99,99,0,0,88};
            array.bubbelSorting();
            foreach(int a in array)
                System.Console.Write(a + " ");
        }
    }
}