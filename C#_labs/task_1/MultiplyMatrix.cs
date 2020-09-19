using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task_1
{
    class MultiplyMatrix
    {
        const int L = 200; // Размер матриц
        const int M = 300; // Размер матриц
        const int N = 400; // Размер матриц
        static void Main(string[] args)
        {
            // Определение прямоугольных и вложенных массивов
            int[,] matrix1, matrix2, matrix3;
            int[][] arr1, arr2, arr3;

            // Создание массивов и вложенных массивов
            matrix1 = new int[L, M];
            matrix2 = new int[M, N];
            matrix3 = new int[L, N];

            arr1 = new int[L][];
            arr2 = new int[N][];
            arr3 = new int[L][];

            // Заполнение массивов и вложенных массивов
            fillMatrix(matrix1, L, M);
            fillMatrix(matrix2, M, N);

            fillArray(arr1, L, N);
            fillArray(arr2, N, L);

            // Произведение массивов и вложенных массивов, подсчет времение выполнения произведения в миллисекундах 
            Stopwatch sw;
            long duration;

            sw = Stopwatch.StartNew();
            multiplyMatrix(matrix1, matrix2, matrix2);
            sw.Stop();
            duration = sw.ElapsedMilliseconds;
            Console.WriteLine("Время умножения матриц " + duration + " мс");

            sw = Stopwatch.StartNew();
            multiplyArray(arr1, arr2, arr3);
            sw.Stop();
            duration = sw.ElapsedMilliseconds;
            Console.WriteLine("Время умножения вложенных массивов " + duration + " мс");

            Console.ReadKey();
        }

        static void multiplyMatrix(int[,] matrix1, int[,] matrix2, int [,] matrix3)
        {
            for (int i = 0; i < L; i++)
                for (int j = 0; j < N; j++)
                {
                    int cc = 0;
                    for (int k = 0; k < M; k++)
                        cc += matrix1[i, k] * matrix2[k, j];
                    matrix3[i, j] = cc;
                }
        }

        static void multiplyArray(int[][] array1, int[][] array2, int[][] array3)
        {
            for (int i = 0; i < L; i++)
            {
                array3[i] = new int[L];
                for (int j = 0; j < L; j++)
                {
                    for (int n = 0; n < N; n++)
                    {
                        array3[i][j] += array1[i][n] * array2[n][j];
                    }
                }
            }
        }

        static void fillMatrix(int[,] matrix, int A, int B)
        {
            Random random = new Random();
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < B; j++)
                {
                    matrix[i, j] = random.Next();
                }
            }
        }

        static void fillArray(int[][] array, int A, int B)
        {
            Random random = new Random();
            for (int i = 0; i < A; i++)
            {
                array[i] = new int[B];
                for (int j = 0; j < B; j++)
                {
                    array[i][j] = random.Next();
                }
            }
        }
    }
}
