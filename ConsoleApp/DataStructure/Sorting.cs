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