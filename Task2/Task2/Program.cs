using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Box<Apple> boxOfApples1 = new Box<Apple>();
        boxOfApples1.AddFruit(new Apple());
        boxOfApples1.AddFruit(new Apple());
        boxOfApples1.AddFruit(new Apple());

        Box<Apple> boxOfApples2 = new Box<Apple>();
        boxOfApples2.AddFruit(new Apple());
        boxOfApples2.AddFruit(new Apple());
        boxOfApples2.AddFruit(new Apple());

        Box<Orange> boxOfOranges1 = new Box<Orange>();
        boxOfOranges1.AddFruit(new Orange());
        boxOfOranges1.AddFruit(new Orange());

        Console.WriteLine($"Вес первой коробки с яблоками: {boxOfApples1.GetWeight()}");
        Console.WriteLine($"Вес второй коробки с яблоками: {boxOfApples2.GetWeight()}");
        Console.WriteLine($"Вес первой коробки с апельсинами: {boxOfOranges1.GetWeight()}");

        if(boxOfApples1.Compare(boxOfApples2))
        {
            Console.WriteLine("Коробки с яблоками равны");
        }
        else
        {
            Console.WriteLine("Коробки с яблоками не равны");
        }

        if (boxOfApples1.Compare(boxOfOranges1))
        {
            Console.WriteLine("Коробка с яблоками и коробка с апельсинами равны");
        }
        else
        {
            Console.WriteLine("Коробка с яблоками и коробка с апельсинами не равны");
        } 

        boxOfApples1.TransferFruits(boxOfApples2, 2);

        Console.WriteLine($"Вес первой коробки с яблоками после перемещения: {boxOfApples1.GetWeight()}");
        Console.WriteLine($"Вес второй коробки с яблоками после перемещения: {boxOfApples2.GetWeight()}");
    }
}