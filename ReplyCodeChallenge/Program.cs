using System;
using System.Collections.Generic;
using System.IO;

namespace ReplyCodeChallenge
{
    class Program
    {
        ///////////////////////// LETTURA /////////////////////////
        public static (string, int[][]) ReadTextFile(string filePath)
        {
            string firstLine = null;
            List<int[]> numbers = new List<int[]>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                // Read the first line
                firstLine = sr.ReadLine();

                // Read the remaining lines
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Split the line by space and parse each number
                    string[] parts = line.Split(' ');
                    int[] rowNumbers = new int[parts.Length];
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (int.TryParse(parts[i], out int number))
                        {
                            rowNumbers[i] = number;
                        }
                    }
                    numbers.Add(rowNumbers);
                }
            }

            // Convert the list of arrays to a 2D array
            int[][] numbersArray = numbers.ToArray();

            return (firstLine, numbersArray);
        }
        /////////////////////////// SCRITTURA ///////////////////////////
        public static void WriteToFile(string filePath, string text)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }
        }
        ///////////////////////// /////////// /////////////////////////
        static void Main(string[] args)
        {
            ///////////////////////// LETTURA
            (string firstLine, int[][] numbersArray) = ReadTextFile("C:/Users/Joey/Desktop/ReplyCodeChallenge/ReplyCodeChallenge/bin/Files/Input.txt");

            // Possiamo quindi usare le variabili per accedere alla prima riga e alla matrice di numeri
            Console.WriteLine($"Case: {firstLine}");

            for (int i = 0; i < numbersArray.Length; i++)
            {
                for (int j = 0; j < numbersArray[i].Length; j++)
                {
                    Console.Write($"{numbersArray[i][j]} ");
                }
                Console.WriteLine();

            }

            ///////////////////////// SCRITTURA
            string filePath = @"C:/Users/Joey/Desktop/ReplyCodeChallenge/ReplyCodeChallenge/bin/Files/Output.txt";
            string message = "Questo è un messaggio di prova.";

            WriteToFile(filePath, message);
        }
    }
}
