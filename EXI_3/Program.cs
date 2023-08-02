// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


int rowsA = GetNum("Введите кол-во строк для матрицы A ");
int colsA = GetNum("Введите кол-во столбов для матрицы А ");
int rowsB = GetNum("Введите кол-во строк для матрицы В ");
int colsB = GetNum("Введите кол-во столбцов для матрицы В ");

int[,] matrixA = GenerateMatrix(rowsA, colsA);
int[,] matrixB = GenerateMatrix(rowsB, colsB);

Console.WriteLine("Матрица A:");
PrintMatrix(matrixA);

Console.WriteLine("Матрица B:");
PrintMatrix(matrixB);

int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);

Console.WriteLine("Результирующая матрица:");
PrintMatrix(resultMatrix);

int GetNum(string message)
{
    Console.Write(message);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] GenerateMatrix(int rows, int cols)
{
    Random random = new Random();
    int[,] matrix = new int[rows, cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = random.Next(1, 10); // Генерируем случайное число от 1 до 9
        }
    }

    return matrix;
}

int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int rowsB = matrixB.GetLength(0);
    int colsB = matrixB.GetLength(1);

    if (colsA != rowsB)
    {
        throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы.");
    }

    int[,] resultMatrix = new int[rowsA, colsB];

    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < colsB; j++)
        {
            int sum = 0;
            for (int k = 0; k < colsA; k++)
            {
                sum += matrixA[i, k] * matrixB[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }

    return resultMatrix;
}

void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

