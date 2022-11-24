using static System.Console;
using System;

internal class Program
{
    static void Main()
    {
        Write("Укажите число строк в матрице: ");
        byte rowA = byte.Parse(ReadLine());

        Write("Задайте число столбцов в матрице: ");
        byte colA = byte.Parse(ReadLine());

        int[,] matrixA = new int[rowA, colA];

        Random randVal = new Random();

        int sumElems = 0;

        WriteLine("\nИнициализированная матрица: ");
        for (int row = 0; row < matrixA.GetLength(0); row++)
        {
            for (int col = 0; col < matrixA.GetLength(1); col++)
            {
                matrixA[row, col] = randVal.Next(0, 100);
                sumElems += matrixA[row, col];
                Write($"{matrixA[row, col], 3}");
            }
            WriteLine();
        }
        WriteLine($"\nРезультат суммы элементов матрицы: {sumElems}");
        ReadKey(true);
    }
}
