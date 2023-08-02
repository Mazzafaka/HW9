// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int row = GetNum("Введите кол-во строк ");
int column = GetNum("Введите кол-во строк ");
int[,] array = GetArray(row, column);
System.Console.WriteLine("Изначальный массив");
PrintArray(array);
FindRowWithMinSum(array);



int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] GetArray(int rows, int columns)
{
    int[,] res = new int[rows, columns];
    Random random = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int randomValue = random.Next(1, 100); 
            res[i, j] = randomValue;
        }
    }
    return res;
}

int FindRowWithMinSum(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int minSum = int.MaxValue;
    int minSumRowIndex = -1;

    for (int i = 0; i < rows; i++)
    {
        int currentSum = 0;

        for (int j = 0; j < columns; j++)
        {
            currentSum += array[i, j];
        }

        if (currentSum < minSum)
        {
            minSum = currentSum;
            minSumRowIndex = i;
        }
    }
        Console.WriteLine($"Строка с наименьшей суммой элементов: {minSumRowIndex + 1}");

    return minSumRowIndex;
}


void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}