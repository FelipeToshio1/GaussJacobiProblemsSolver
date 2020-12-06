using System;
using System.Collections.Generic;

namespace AlgebraLinear
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetMatrix();

            var diagonal = GetMainDiagonal(matrix);

            var check = CheckIfItHasASimpleSolution(matrix, diagonal);

            if (!check)
            {
                Console.WriteLine("Please enter a valid matrix");
            }
            else
            {
                Console.WriteLine("yea boi");
            }

        }

        private static bool CheckIfItHasASimpleSolution(double[,] matrix, List<double> diagonal)
        {
            for (int i = 0; i < diagonal.Count; i++)
            {
                var sum = CatchMatrixLineSum(matrix, i);

                if(Math.Abs(diagonal[i]) < sum)
                {
                    return false;
                }
            }
            return true;
        }

        private static double CatchMatrixLineSum(double[,] matrix, int i)
        {
            var sum = 0.0;
            for (int j = 0; j < 4; j++)
            {
                if (j != i)
                {
                    sum += Math.Abs(matrix[i, j]);
                }
            }
            return sum;
        }

        private static List<double> GetMainDiagonal(double[,] matrix)
        {
            var mainDiagonal = new List<double>();
            
            for(var i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(i == j)
                    {
                        mainDiagonal.Add(matrix[i, j]);    
                    }

                }
            }

            return mainDiagonal;
        }

        public static double[,] GetMatrix()
        {
            return new double[4, 4]
            {
                { 7,1,2,3}, {1,4,1,1}, {1,1,5,2}, {3,2,1,9}
            };

        }
    }
}
