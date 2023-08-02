// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


int row = GetNum("Введите кол-во строк ");
int column = GetNum("Введите кол-во строк ");
int[,] array = GetArray(row, column);

Console.WriteLine("Исходный массив:");
PrintArray(array);
SortRowsDescending(array);

Console.WriteLine("Массив с элементами каждой строки упорядоченными по убыванию:");
PrintArray(array);

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

void SortRowsDescending(int[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            int[] currentRow = new int[columns];
            for (int j = 0; j < columns; j++)
            {
                currentRow[j] = array[i, j];
            }

            Array.Sort(currentRow, (x, y) => y.CompareTo(x));

            for (int j = 0; j < columns; j++)
            {
                array[i, j] = currentRow[j];
            }
        }
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