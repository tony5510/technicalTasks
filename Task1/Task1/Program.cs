using System;

class Program
{
    static void SwapElements<T>(T[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            T temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }

    static void PrintArray<T>(T[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };
        SwapElements(array);
        PrintArray(array);

        string[] array2 = { "one", "two", "three", "four", "five", "six" };
        SwapElements(array2);
        PrintArray(array2);
    }
}