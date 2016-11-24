using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearEquationSystemSolver
{
    public static class Extensions
    {
        public static double SumElements(this double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }

        public static double[] MultWith(this double[] array, double[] factors)
        {
            for (int i = 0; i < factors.Length; i++)
                array[i] *= factors[i];
            return array;
        }

        public static double[] MultBy(this double[] array, double factor)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] *= factor;
            return array;
        }

        public static double[,] AddToRow(this double[,] matrix, int row, double[] values)
        {
            var width = matrix.GetLength(1);
            var height = matrix.GetLength(0);

            if (values.Length != width)
                throw new ArgumentOutOfRangeException("Matrix width and provided row length do not match");
            if (row >= height)
                throw new IndexOutOfRangeException("Row Out of Range");

            for (int i = 0; i < values.Length; i++)
                matrix[row, i] += values[i];

            return matrix;
        }


        public static int MaxElementIndex<T>(this T[] array) where T : IComparable
        {
            int index = 0;
            T max = array[index];

            for (int i = 1; i < array.Length; i++)
                if (max.CompareTo(array[i]) < 0)
                {
                    index = i;
                    max = array[i];
                }

            return index;
        }

        public static double[] Abs(this double[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);

            return array;
        }

        public static T[] StartingAt<T>(this T[] array, int from) where T : IComparable
        {
            if (array.Length <= from)
                throw new IndexOutOfRangeException("Element Out of Range");

            T[] part = new T[array.Length - from];

            for (int i = 0; i < part.Length; i++)
                part[i] = array[i + from];

            return part;
        }

        public static T[] Coefficients<T>(this T[] array) where T : IComparable
        {
            T[] coefficients = new T[array.Length - 1];
            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] = array[i];
            return coefficients;
        }

        public static T[] Column<T>(this T[,] matrix, int column) where T : IComparable
        {
            if (column >= matrix.ColumnCount())
                throw new IndexOutOfRangeException("Column Index Out of Range");

            T[] extractedColumn = new T[matrix.RowCount()];
            for (int i = 0; i < matrix.RowCount(); i++)
                extractedColumn[i] = matrix[i, column];

            return extractedColumn;
        }

        public static T[] Row<T>(this T[,] matrix, int row) where T : IComparable
        {
            if (row >= matrix.RowCount())
                throw new IndexOutOfRangeException("Column Index Out of Range");

            T[] extractedRow = new T[matrix.ColumnCount()];
            for (int i = 0; i < matrix.ColumnCount(); i++)
                extractedRow[i] = matrix[row, i];

            return extractedRow;
        }

        public static void Print<T>(this T[,] matrix) where T : IComparable
        {
            for (int i = 0; i < matrix.RowCount(); i++)
            {
                matrix.Row(i).Print();
            }
            Console.WriteLine();
        }

        public static void Print<T>(this T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0:F3}\t", array[i]);
            }
            Console.WriteLine();
        }

        public static T[,] SwapRows<T>(this T[,] matrix, int row1, int row2) where T : IComparable
        {
            var width = matrix.GetLength(1);
            var height = matrix.GetLength(0);

            if (Math.Max(row1, row2) >= height)
                throw new IndexOutOfRangeException("Row Index Out of Range");

            for (var i = 0; i < width; i++)
            {
                T tmp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = tmp;
            }

            return matrix;
        }

        public static int RowCount<T>(this T[,] matrix)
        {
            return matrix.GetLength(0);
        }

        public static int ColumnCount<T>(this T[,] matrix)
        {
            return matrix.GetLength(1);
        }
    }
}
