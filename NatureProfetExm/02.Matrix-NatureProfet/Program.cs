

using System;
using System.Linq;

namespace _02.Matrix_NatureProfet
{
    class Program
    {
        static void Main()
        {
            int[] inp = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = inp[0];
            int m = inp[1];

            int[][] matrix = FillMatrix(n, m);
            
            var position = Console.ReadLine();
               
            while (position != "Bloom Bloom Plow")
            {
                var tokens = position
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                var rows = tokens[0];
                var cols = tokens[1];

                makeMagic(rows, cols, matrix);

                position = Console.ReadLine();
            }


            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[][] FillMatrix(int n, int m)
        {
            int[][] matrix = new int[n][];

            for (int rows = 0; rows < n; rows++)
            {
                matrix[rows] = new int[m];
                for (int cols = 0; cols < m; cols++)
                {
                    matrix[rows][cols] = 0;
                }
            }

            return matrix;
        }

        private static void makeMagic(int rows, int cols, int[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++) //len-1
                {
                    if ((r == rows || c == cols)) 
                    {
                        matrix[r][c]++;
                    }
                }
            }
        }
    }
}
