using MatrixTaskLib;
using System;
using System.Numerics;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix();

            matrix.Print();
            Console.WriteLine();

            while (true)
            {
                matrix.DeleteDuplicates();
                matrix.Print();
                Console.WriteLine();

                matrix.ShiftDown();
                matrix.Print();
                Console.WriteLine();

                if (matrix.ContainsNulls())
                    matrix.InsertRandomIntoNulls();
                else 
                    break;
            }
        }
    }
}