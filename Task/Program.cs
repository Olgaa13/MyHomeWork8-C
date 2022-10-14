// Task54();
// Task56();
// Task58();
// Task60();
// Task62();


void Task54()
{
    // Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
    // по убыванию элементы каждой строки двумерного массива.
    // Например, задан массив:
    // 1 4 7 2
    // 5 9 2 3
    // 8 4 2 4
    // В итоге получается вот такой массив:
    // 7 4 2 1
    // 9 5 3 2
    // 8 4 4 2
    Console.Clear();
    Console.Write("задайте количество строк в массиве: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("задайте количество строк в массиве: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    SortArray(matrix);
    Console.WriteLine("Отсортированные элементы строк массива по убыванию:");
    PrintArray(matrix);
}
void FillArray(int[,] array)
{
    Random random = new Random();
    int sizeRowsArray = array.GetLength(0);
    int sizeColumnsArray = array.GetLength(1);
    for (int i = 0; i < sizeRowsArray; i++)
    {
        for (int j = 0; j < sizeColumnsArray; j++)
        {
            array[i, j] = random.Next(1, 50);
        }
    }
}

void PrintArray(int[,] array)
{
    int sizeRowsArray = array.GetLength(0);
    int sizeColumnsArray = array.GetLength(1);
    for (int i = 0; i < sizeRowsArray; i++)
    {
        for (int j = 0; j < sizeColumnsArray; j++)
        {
            Console.Write(array[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void SortArray(int[,] array)
{
    int sizeRowsArray = array.GetLength(0);
    int sizeColumnsArray = array.GetLength(1);
    for (int i = 0; i < sizeRowsArray; i++)
    {
        for (int j = 0; j < sizeColumnsArray; j++)
        {
            for (int k = j; k < sizeColumnsArray; k++)
            {
                if (array[i, k] > array[i, j])
                {
                    int temp = array[i, k];
                    array[i, k] = array[i, j];
                    array[i, j] = temp;
                }
            }
        }
    }
}




void Task56()
{
    // Задача 56: Задайте прямоугольный двумерный массив. 
    // Напишите программу, которая будет находить строку с наименьшей суммой элементов.
    // Программа считает сумму элементов в каждой строке и выдаёт
    //  номер строки с наименьшей суммой элементов: 1 строка


    Random plsNoCube = new Random();
    int rows = plsNoCube.Next(2, 7);
    int columns = plsNoCube.Next(2, 7);
    if (rows == columns) { columns++; }
    int[,] matrix = new int[rows, columns];
    FillArray(matrix);
    PrintArray(matrix);
    Console.WriteLine($"Наименьшая сумма элементов у {LowSummElements(matrix)}й строки масива");
}

int LowSummElements(int[,] arr)
{
    int rowsSize = arr.GetLength(0);
    int columnsSize = arr.GetLength(1);
    int minSummRow = 0;
    int sumRowElements = 0;
    for (int j = 0; j < columnsSize; j++)
    {
        sumRowElements = sumRowElements + arr[0, j];
    }
    int MinSumm = sumRowElements;
    for (int i = 1; i < rowsSize; i++)
    {
        sumRowElements = 0;
        for (int j = 0; j < columnsSize; j++)
        {
            sumRowElements = sumRowElements + arr[i, j];
        }
        if (sumRowElements < MinSumm)
        {
            MinSumm = sumRowElements;
            minSummRow = i + 1;
        }
    }
    return minSummRow;
}




void Task58()
{
    // Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    // Например, даны 2 матрицы:
    // 2 4 | 3 4
    // 3 2 | 3 3
    // Результирующая матрица будет:
    // 18 20
    // 15 18

    Console.Clear();
    Console.WriteLine("Введите размеры матриц и диапазон случайных значений:");
    int m = InputNumbers("Введите число строк 1-й матрицы: ");
    int n = InputNumbers("Введите число столбцов 1-й матрицы (и строк 2-й): ");
    int p = InputNumbers("Введите число столбцов 2-й матрицы: ");
    
    int[,] firstMartrix = new int[m, n];
    FillArray(firstMartrix);
    Console.WriteLine($"Первая матрица:");
    PrintArray(firstMartrix);

    int[,] secomdMartrix = new int[n, p];
    FillArray(secomdMartrix);
    Console.WriteLine($"Вторая матрица:");
    PrintArray(secomdMartrix);

    int[,] resultMatrix = new int[m, p];

    MultiplyMatrix(firstMartrix, secomdMartrix, resultMatrix);
    Console.WriteLine($"Произведение первой и второй матриц:");
    PrintArray(resultMatrix);
}

    void MultiplyMatrix(int[,] firstMartrix, int[,] secomdMartrix, int[,] resultMatrix)
    {
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int k = 0; k < firstMartrix.GetLength(1); k++)
                {
                    sum += firstMartrix[i, k] * secomdMartrix[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }
    }

    int InputNumbers(string input)
    {
        Console.Write(input);
        int output = Convert.ToInt32(Console.ReadLine());
        return output;
    }





void Task60()
{
    //Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
    // Напишите программу, которая будет построчно выводить массив,
    // добавляя индексы каждого элемента.
    // Массив размером 2 x 2 x 2
    // 66(0,0,0) 25(0,1,0)
    // 34(1,0,0) 41(1,1,0)
    // 27(0,0,1) 90(0,1,1)
    // 26(1,0,1) 55(1,1,1)

    Console.Clear();

    Console.Write("Ведите кол-во строк: ");
    int x = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Ведите кол-во колонн: ");
    int y = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Ведите глубину: ");
    int z = int.Parse(Console.ReadLine() ?? "0");

    int[,,] mainArray = new int[x, y, z];

    FillArray(mainArray);
    PrintArray(mainArray);
    Console.WriteLine();

    void FillArray(int[,,] array)
    {
        string[] stringArray = new string[array.GetLength(0) *
                                          array.GetLength(1) *
                                          array.GetLength(2)];
        int stringCount = 0;
        Random rnd = new Random();

        for (int k = 0; k < array.GetLength(2); k++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j, k] = rnd.Next(10, 100);
                    while (stringArray.Contains(Convert.ToString(array[i, j, k])))
                        array[i, j, k] = rnd.Next(10, 100);
                    stringArray[stringCount] = Convert.ToString(array[i, j, k]);
                    stringCount++;
                }
            }
        }
    }

    void PrintArray(int[,,] array)
    {
        for (int k = 0; k < array.GetLength(2); k++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}



void Task62()
{
    // Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
    // Например, на выходе получается вот такой массив:
    // 01 02 03 04
    // 12 13 14 05
    // 11 16 15 06
    // 10 09 08 07

    Console.Clear();

    Console.Write("Ведите кол-во строк: ");
    int x = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Ведите кол-во столбцов: ");
    int y = int.Parse(Console.ReadLine() ?? "0");

    int[,] mainArray = new int[x, y];

    FillArrayWithSpiral(mainArray);
    PrintArray(mainArray);
    Console.WriteLine();

    void FillArrayWithSpiral(int[,] array, int i = 0, int j = 0)
    {
        int temp = 1;

        while (temp <= array.GetLength(0) * array.GetLength(1))
        {
            array[i, j] = temp;
            temp++;
            if (i <= j + 1 && i + j < array.GetLength(1) - 1)
                j++;
            else if (i < j && i + j >= array.GetLength(0) - 1)
                i++;
            else if (i >= j && i + j > array.GetLength(1) - 1)
                j--;
            else
                i--;
        }
    }
    void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            Console.Write("[ ");
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < 10)
                    Console.Write($"0{array[i, j]} ");
                else
                    Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}