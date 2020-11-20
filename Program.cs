using System;
using System.Linq;

namespace TDI_Task_07
{
    class Program
    {
        static Random rand = new Random();

        static int[,] Shuffle(int[,] matrix)
        {
            int howManyRows = matrix.GetLength(0);
            int howManyColumns = matrix.GetLength(1);
            
            int[,] randomizedMatrix = new int[howManyRows, howManyColumns];
            
            //we will use those arrays to randomize indexes
            int[] shuffledRowIndexes = Enumerable.Range(0, howManyRows).ToArray();
            int[] shuffledColumnIndexes = Enumerable.Range(0, howManyColumns).ToArray();
            
            shuffledRowIndexes = shuffledRowIndexes.OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < howManyRows; i++)
            {
                // at every loop we get new randomized column idexes, so every row will be shuffled independently
                shuffledColumnIndexes = shuffledColumnIndexes.OrderBy(x => rand.Next()).ToArray();
                
                for (int j = 0; j < howManyColumns; j++)
                {
                    randomizedMatrix[i, j] = matrix[shuffledRowIndexes.ElementAt(i), shuffledColumnIndexes.ElementAt(j)];
                }
            }

            return randomizedMatrix;
        }

        static void Main()
        {
            Console.Write("Enter a array size: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[,] array = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = rand.Next(1, 15);
                }
            }

            Console.WriteLine("\n||| Original Array |||\n");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }

            array = Shuffle(array);

            Console.WriteLine("\n||| Shuffled Array |||\n");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }

                Console.WriteLine("\n");
            }
        }
    }
}
