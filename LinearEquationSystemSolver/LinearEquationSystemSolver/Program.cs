using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystemSolver
{
    class Program
    {


        static void Main(string[] args)
        {
            //double[,] matrix = {{  1, -2,  1,  2 },
            //             {  2, -5, -1, -1 },
            //             { -7,  0,  1, -2 }};

            double[,] matrix = {{  5, -5,  -3,  4, -11 },
                                {  1, -4, -6, -4, -10 },
                                {  -2, -5, 4, -5, -12 },
                                { -3,  -3,  5, -5, 8 }};

            double[,] initial = matrix.Clone() as double[,];

            matrix.Print();

            Console.WriteLine("Forward walkthrough");
            for (int i = 0; i < matrix.RowCount() - 1; i++)
            {
                Console.WriteLine("Iteration {0}", i + 1);
                matrix
                    .SwapRows(i, matrix
                                    .Column(i)
                                    .StartingAt(i)
                                    .Abs()
                                    .MaxElementIndex() + i)
                    .Print();

                for (int j = i + 1; j < matrix.RowCount(); j++)
                {
                    Console.WriteLine("Sub iteration {0}", j - i);
                    matrix
                        .AddToRow(j, matrix
                                        .Row(i)
                                        .MultBy(-matrix[j, i] / matrix[i, i]))
                        .Print();
                }
            }

            Console.WriteLine("Backward walkthrough");
            double[] solution = new double[matrix.RowCount()];
            for (int i = matrix.RowCount() - 1; i >= 0; i--)
            {
                solution[i] = (matrix[i, matrix.ColumnCount() - 1] -
                              matrix
                                .Row(i)
                                .Coefficients()
                                .MultWith(solution)
                                .SumElements()) /
                               matrix[i, i];
                solution.Print();
            }

            Console.WriteLine("Check");
            for (int i = 0; i < initial.RowCount(); i++)
            {
                Console.WriteLine("Equation {0}:", i + 1);
                initial.Row(i).Print();
                double delta = initial[i, initial.ColumnCount() - 1] -
                               initial
                                .Row(i)
                                .Coefficients()
                                .MultWith(solution)
                                .SumElements();
                Console.WriteLine("Delta: {0}", delta);
            }
        }
    }

}