using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgebraLinear
{
    class Program
    {

        private static readonly double[,] matrix = new double[4, 4]
            {
                {7,1,2,3}, {1,4,1,1}, {1,1,5,2}, {3,2,1,9}
            };

        private static readonly double[] vectorResult = new double[]
        {
            3,4,5,6
        };

        private static readonly double marginOfError = 0.01;

        static void Main(string[] args)
        {

            var diagonal = GetMainDiagonal();

            var check = CheckIfItHasASimpleSolution(diagonal);

            if (!check)
            {
                Console.WriteLine("Please enter a valid matrix");
            }
            else
            {
                var result = GaussJacobiSolver();
                for (int i = 0; i < result.Count; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }

        }

        private static List<double> GaussJacobiSolver()
        {
            var auxNumbers = new List<double>()
            {
                0,0,0,0
            };

            var auxList = new List<double>()
            {
                0,0,0,0
            };

            bool isAboveMarginOfError = false;

            var iterations = 0;
            var maxIterations = 50;

            double total;

            while (!isAboveMarginOfError)
            {

                for (var i = 0; i < matrix.GetLength(0); i++)
                {
                    total = vectorResult[i];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        //Check if is not from the main diagonal
                        if (i != j)
                        {
                            total -= matrix[i, j] * auxNumbers[j];
                        }
                    }
                    auxList[i] = total / matrix[i, i];
                }

                isAboveMarginOfError = CheckMarginOfError(auxNumbers, auxList);
                
                auxNumbers = new List<double>(auxList);
                iterations++;
            }

            Console.WriteLine(iterations);
            return auxNumbers;
        }

        private static bool CheckMarginOfError(List<double> oldList, List<double> newList)
        {
            for (int i = 0; i < oldList.Count; i++)
            {
                var something = newList[i] - oldList[i];
                if (Math.Abs(something) > marginOfError)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckIfItHasASimpleSolution(List<double> diagonal)
        {
            for (int i = 0; i < diagonal.Count; i++) //this can be changed to a foreach
            {
                var sum = CatchMatrixLineSum(i);

                if (Math.Abs(diagonal[i]) < sum)
                {
                    return false;
                }
            }
            return true;
        }

        private static double CatchMatrixLineSum(int i)
        {
            var sum = 0.0;
            for (int j = 0; j < 4; j++) //it has to be another way to this for
            {
                if (j != i)
                {
                    sum += Math.Abs(matrix[i, j]);
                }
            }
            return sum;
        }

        private static List<double> GetMainDiagonal()
        {
            var mainDiagonal = new List<double>();

            for (var i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        mainDiagonal.Add(matrix[i, j]);
                    }

                }
            }

            return mainDiagonal;
        }

    }
}
