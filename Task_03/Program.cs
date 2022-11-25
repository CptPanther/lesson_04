using System;
using static System.Console;
using System.Threading;
using System.Diagnostics;

internal class Program
{
    //Основная программа.
    static void Main()
    {
        Write("Укажите количество строк: ");
        byte rowM = byte.Parse(ReadLine());

        Write("Укажите количество столбцов: ");
        byte colM = byte.Parse(ReadLine());

        bool[,] curWorld = GenerateWorld(rowM, colM);
        byte countIter = 0;

        while (countIter++ < 100)
        {
            DrawWorld(curWorld);
            ChangedWorld(curWorld);
            Thread.Sleep(100);   
        }
        SetCursorPosition(0, curWorld.GetLength(0)-2);
        WriteLine("\nПрограмма завершена.");
        ReadKey(true);
    }

    //Генерация мира.
    static bool[,] GenerateWorld(byte rowW, byte colW)
    {
        bool[,] world = new bool[rowW + 2, colW + 2];
        int flag = 0;

        Random randBool = new Random();

        for (byte row = 1; row < world.GetLength(0) - 1; row++)
        {
            for (byte col = 1; col < world.GetLength(1) - 1; col++)
            {
                flag = randBool.Next(2);
                world[row, col] = (flag == 0) ? false : true;
            }
        }
        return world;
    }

    //Итерация мира.
    static void ChangedWorld(bool[,] sourceWorld)
    {
        AddBorderElems(sourceWorld);
        
        //Прохождение по клеткам.
        for (byte posY = 1; posY < sourceWorld.GetLength(0) - 1; posY++)
        {
            for (byte posX = 1; posX < sourceWorld.GetLength(1) - 1; posX++)
            {
                byte counterCell = 0;

                //Проверяет окружение клетки.
                //При положительном результате итерирует на +1 счетчик counterCell
                for (byte row = Convert.ToByte(posY - 1); row < posY + 2; row++)
                {
                    for (byte col = Convert.ToByte(posX - 1); col < posX + 2; col++)
                    {
                        if (col == posX && row==posY)
                            continue;
                        else if (sourceWorld[row, col])
                            counterCell++;
                    }
                }

                //Условия игры
                if ((counterCell > 3 || counterCell < 2) && sourceWorld[posY, posX])
                    sourceWorld[posY, posX] = false;
                else if (counterCell == 3 && !sourceWorld[posY, posX])
                    sourceWorld[posY, posX] = true;
            }
        }
        //return sourceWorld;
    }

    //Прорисовка мира.
    static void DrawWorld(bool[,] world)
    {
        Clear();
        for (byte row = 1; row < world.GetLength(0)-1; row++)
        {
            for (byte col = 1; col < world.GetLength(1)-1; col++)
                Write(world[row, col] ? "* " : "  ");
            WriteLine();
        }
        SetCursorPosition(0, WindowTop);
        CursorVisible = false;
    }

    /* Первый цикл:
     * Заносит значения с предпоследнего столбца в первый в позиции posY.
     * Заносит значения со второго столбца в последний в позиии posY.
     * Второй цикл:
     * Заносит значения с предпоследней строки в первую в позиции posX.
     * Заносит значения со второй строки в последнюю в позиии posX.
     * 
     * т.к. по условиям задачи верхняя граница мира связана с нижней, 
     * а левая граница с правой.
     */
    static void AddBorderElems(bool[,] sourceWorld)
    {
        for (byte posY = 1; posY < sourceWorld.GetLength(0) - 1; posY++)
        {
            sourceWorld[posY, 0] = sourceWorld[posY, sourceWorld.GetLength(1) - 2];
            sourceWorld[posY, sourceWorld.GetLength(1) - 1] = sourceWorld[posY, 1];
        }

        for (byte posX = 1; posX < sourceWorld.GetLength(1) - 1; posX++)
        {
            sourceWorld[0, posX] = sourceWorld[sourceWorld.GetLength(0) - 2, posX];
            sourceWorld[sourceWorld.GetLength(0) - 1, posX] = sourceWorld[1, posX];
        }
    }
}
