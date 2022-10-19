using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTaskLib
{
    public static class Logic
    {
        public static void DeleteDuplicates(this Matrix matrix, CheckFirstAxis firstAxis = CheckFirstAxis.Horizontal, int minNumOfDuplicates = 3)
        {
            if (firstAxis == CheckFirstAxis.Horizontal)
            {
                DeleteHorizontalDuplicates(matrix, minNumOfDuplicates);
                DeleteVerticalDuplicates(matrix, minNumOfDuplicates);
            }
            else if (firstAxis == CheckFirstAxis.Vertical)
            {
                DeleteVerticalDuplicates(matrix, minNumOfDuplicates);
                DeleteHorizontalDuplicates(matrix, minNumOfDuplicates);
            }
        }

        private static void DeleteHorizontalDuplicates(Matrix matrix, int minNumOfDuplicates)
        {
            int num = 1; // number of duplicates of the current number
            int startIndex = 0; // index where the duplicate sequence starts
            int endIndex = 0; // ... where it ends

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        if (num == 1) startIndex = j;
                        endIndex = j + 1;
                        num++;
                    }
                    else
                    {
                        if (num >= minNumOfDuplicates)
                        {
                            // delete duplicates
                            matrix.DeleteSequenceInRow(startIndex, endIndex, i);
                        }
                        num = 1;
                    }

                }

                // TODO - fix last element in a row iteration
                if (num >= minNumOfDuplicates)
                {
                    // delete duplicates
                    matrix.DeleteSequenceInRow(startIndex, endIndex, i);
                }
                num = 1;
            }
        }
        private static void DeleteVerticalDuplicates(Matrix matrix, int minNumOfDuplicates)
        {
            int num = 1; // number of duplicates of the current number
            int startIndex = 0; // index where the duplicate sequence starts
            int endIndex = 0; // ... where it ends

            for (int j = 0; j < matrix.Columns; j++)
            {
                for (int i = 0; i < matrix.Rows - 1; i++)
                {
                    if (matrix[i, j] == matrix[i+1, j])
                    {
                        if (num == 1) startIndex = j;
                        endIndex = j + 1;
                        num++;
                    }
                    else
                    {
                        if (num >= minNumOfDuplicates)
                        {
                            // delete duplicates
                            matrix.DeleteSequenceInColumn(startIndex, endIndex, j);
                        }
                        num = 1;
                    }

                }

                // TODO - fix last element in a row iteration
                if (num >= minNumOfDuplicates)
                {
                    // delete duplicates
                    matrix.DeleteSequenceInColumn(startIndex, endIndex, j);
                }
                num = 1;
            }
        }
        private static void DeleteSequenceInRow(this Matrix matrix, int startIndex, int endIndex, int row)
        {
            for (int j = startIndex; j <= endIndex; j++)
            {
                matrix[row, j] = null;
            }
        }
        private static void DeleteSequenceInColumn(this Matrix matrix, int startIndex, int endIndex, int column)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                matrix[i, column] = null;
            }
        }

        // TODO - come up with something better than O(n^3)
        public static void ShiftDown(this Matrix matrix)
        {
            for (int repeat = 0; repeat < matrix.Rows / 2; repeat++)
            {
                for (int i = matrix.Rows - 1; i > 0; i--)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        if (matrix[i, j] == null)
                        {
                            if (matrix[i - 1, j] != null)
                            {
                                (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            }
                        }
                    }
                }
            }

        }
        public static void InsertRandomIntoNulls(this Matrix matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] == null)
                        matrix[i, j] = rand.Next(4);
                }
            }
        }
        public static bool ContainsNulls(this Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] == null)
                        return true;
                }
            }
            return false;
        }
    }
}
