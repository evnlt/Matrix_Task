using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTaskLib
{
    public class Matrix
    {
        private readonly int?[,] _matrix;
        // TODO - Rows, Columns >= 3
        public int Rows { get; } = 9;
        public int Columns { get; } = 9;

        public Matrix()
        {
            _matrix = InitRandom(Rows, Columns);
        }

        public Matrix(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            _matrix = InitRandom(rows, columns);
        }
        public int? this[int i, int j]
        {
            get => _matrix[i, j];
            set => _matrix[i, j] = value;
        }

        private int?[,] InitRandom(int rows, int columns)
        {
            int?[,] matrix = new int?[rows, columns];
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(4);
                }
            }

            return matrix;
        }
    }
}
