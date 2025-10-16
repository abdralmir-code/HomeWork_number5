using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание номер 6.1
            Console.WriteLine("Задание номер 6.1");
            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
            char[] consonants = { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
            string text = File.ReadAllText(@"C:\СИ ШАРП\Latypova_and_Tumakov\Tumakov\bin\Debug\text.txt");
            char[] symbols = text.ToCharArray();
            int total1 = 0;
            int total2 = 0;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (vowels.Contains(symbols[i]))
                {
                    total1++;
                }
                else if (consonants.Contains(symbols[i]))
                {
                    total2++;
                }
            }
            Console.WriteLine($"Количество гласных {total1}");
            Console.WriteLine($"Количество согласных {total2}");
            Console.WriteLine();

            // Задание номер 6.2
            Console.Write("Задание номер 6.2");
            int[,] Matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] Matrix2 = { { 5, 6 }, { 7, 8 } };
            int[,] result = MultiplyMatrices(Matrix1, Matrix2);
            Console.WriteLine("\nРезультат умножения:");
            PrintMatrix(result);
            Console.WriteLine();

            // Задание номер 6.3 с использованием Dictionary
            Console.WriteLine("Задание номер 6.3 с Dictionary");
            string[] monthNames = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь","Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
            int days = 30;
            Random generator = new Random();
            Dictionary<string, int[]> temperatureByMonth = new Dictionary<string, int[]>();
            foreach (var month in monthNames)
            {
                int[] temps = new int[days];
                for (int i = 0; i < days; i++)
                    temps[i] = generator.Next(-30, 36);
                temperatureByMonth[month] = temps;
            }
            Dictionary<string, double> monthlyAveragesDict = new Dictionary<string, double>();
            foreach (var kvp in temperatureByMonth)
            {
                double avg = kvp.Value.Average();
                monthlyAveragesDict[kvp.Key] = avg;
            }
            Console.WriteLine("Средние температуры по месяцам:");
            foreach (var kvp in monthlyAveragesDict)
                Console.WriteLine($"{kvp.Key}: {kvp.Value:F2}°C");
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var kvp in monthlyAveragesDict.OrderBy(x => x.Value))
                Console.WriteLine($"{kvp.Key}: {kvp.Value:F2}°C");
            Console.WriteLine();

            Console.WriteLine("Задание номер 6.3");
            int months = monthNames.Length;
            int[][] temperature = new int[months][];
            double[] monthlyAverages = new double[months];

            for (int i = 0; i < months; i++)
            {
                temperature[i] = new int[days];
                int sum = 0;
                for (int j = 0; j < days; j++)
                {
                    temperature[i][j] = generator.Next(-30, 36);
                    sum += temperature[i][j];
                }
                monthlyAverages[i] = sum / (double)days;
            }

            Console.WriteLine("Средние температуры по месяцам:");
            for (int i = 0; i < months; i++)
                Console.WriteLine($"{monthNames[i]}: {monthlyAverages[i]:F2}°C");
            int[] indices = new int[months];
            for (int i = 0; i < months; i++)
                indices[i] = i;

            for (int i = 0; i < months - 1; i++)
            {
                for (int j = i + 1; j < months; j++)
                {
                    if (monthlyAverages[indices[i]] > monthlyAverages[indices[j]])
                    {
                        int temp = indices[i];
                        indices[i] = indices[j];
                        indices[j] = temp;
                    }
                }
            }

            Console.WriteLine("\nОтсортированные средние температуры:");
            for (int i = 0; i < months; i++)
                Console.WriteLine($"{monthNames[indices[i]]}: {monthlyAverages[indices[i]]:F2}°C");
            Console.WriteLine();

            // Задание номер 6.4
            Console.WriteLine("Задание номер 6.4");
            List<char> vowels2 = new List<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };
            List<char> consonants2 = new List<char> { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'Б', 'В', 'Г', 'Д', 'Ж', 'З', 'Й', 'К', 'Л', 'М', 'Н', 'П', 'Р', 'С', 'Т', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ' };
            string text2 = File.ReadAllText(@"C:\СИ ШАРП\Latypova_and_Tumakov\Tumakov\bin\Debug\text.txt");
            List<char> symbols2 = new List<char>(text2);
            int total3 = 0;
            int total4 = 0;
            for (int i = 0; i < symbols2.Count; i++)
            {
                if (vowels2.Contains(symbols2[i]))
                {
                    total3++;
                }
                else if (consonants2.Contains(symbols2[i]))
                {
                    total4++;
                }
            }
            Console.WriteLine($"Количество гласных {total3}");
            Console.WriteLine($"Количество согласных {total4}");
            Console.WriteLine();

            // Задание номер 6.5 c LinkedList
            Console.Write("Задание номер 6.5 с использованием LinkedList");
            var matrix3 = new LinkedList<LinkedList<int>>();
            matrix3.AddLast(new LinkedList<int>(new[] { 1, 2 }));
            matrix3.AddLast(new LinkedList<int>(new[] { 3, 4 }));
            var matrix4 = new LinkedList<LinkedList<int>>();
            matrix4.AddLast(new LinkedList<int>(new[] { 5, 6 }));
            matrix4.AddLast(new LinkedList<int>(new[] { 7, 8 }));
            var result2 = MultiplyMatricesLinkedList(matrix3, matrix4);
            Console.WriteLine("\nРезультат умножения:");
            PrintMatrix(result2);
        }

        // Метод для печати матрицы
        private static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }
        // Метод для печати матрицы, представленной как LinkedList
        private static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var val in row)
                    Console.Write(val + "\t");
                Console.WriteLine();
            }
        }
        // Метод для умножения двух матриц
        static int[,] MultiplyMatrices(int[,] Matrix1, int[,] Matrix2)
        {
            int rows1 = Matrix1.GetLength(0);
            int cols1 = Matrix1.GetLength(1);
            int cols2 = Matrix2.GetLength(1);

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
                for (int j = 0; j < cols2; j++)
                    for (int k = 0; k < cols1; k++)
                        result[i, j] += Matrix1[i, k] * Matrix2[k, j];

            return result;
        }
        // Метод для умножения двух матриц, представленных как LinkedList
        static LinkedList<LinkedList<int>> MultiplyMatricesLinkedList(
            LinkedList<LinkedList<int>> matrix3,
            LinkedList<LinkedList<int>> matrix4)
        {
            int rows1 = matrix3.Count;
            int cols1 = matrix3.First.Value.Count;
            int cols2 = matrix4.First.Value.Count;

            var result = new LinkedList<LinkedList<int>>();

            var row1Node = matrix3.First;
            for (int i = 0; i < rows1; i++)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    var row1ColNode = row1Node.Value.First;
                    var matrix4RowNode = matrix4.First;
                    for (int k = 0; k < cols1; k++)
                    {
                        var matrix4ColNode = matrix4RowNode.Value.First;
                        for (int l = 0; l < j; l++)
                            matrix4ColNode = matrix4ColNode.Next;
                        sum += row1ColNode.Value * matrix4ColNode.Value;
                        row1ColNode = row1ColNode.Next;
                        matrix4RowNode = matrix4RowNode.Next;
                    }
                    newRow.AddLast(sum);
                }
                result.AddLast(newRow);
                row1Node = row1Node.Next;
            }
            return result;
        }
    }
}