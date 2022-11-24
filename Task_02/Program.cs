using System;
using static System.Console;
internal class Program
{
    static void Main()
    {
        Write("Укажите число строк в матрице: ");
        byte rowM = byte.Parse(ReadLine());

        Write("Задайте число столбцов в матрице: ");
        byte colM = byte.Parse(ReadLine());

        int[,] matrixA = new int[rowM, colM];
        int[,] matrixB = new int[rowM, colM];
        int[,] matrixC = new int[rowM, colM];

        Random randVal = new Random();

        WriteLine("\nМатрица 'A':");
        for (int row = 0; row < rowM; row++)
        {
            for (int col = 0; col < colM; col++)
            {
                matrixA[row, col] = randVal.Next(-9, 10);
                Write($"{matrixA[row, col], 4}");
            }
            WriteLine();
        }

        WriteLine("\nМатрица 'B': ");
        for (int row = 0; row < rowM; row++)
        {
            for (int col = 0; col < colM; col++)
            {
                matrixB[row, col] = randVal.Next(-9, 10);
                Write($"{matrixB[row, col], 4}");
            }
            WriteLine();
        }

        WriteLine("\nРезультат сложения матриц 'A' и 'B': ");
        for (int row = 0; row < rowM; row++)
        {
            for (int col = 0; col < colM; col++)
            {
                matrixC[row, col] = matrixA[row, col] + matrixB[row, col];
                Write($"{matrixC[row, col], 4}");
            }   
            WriteLine();
        }
        ReadKey(true);
    }   
}
