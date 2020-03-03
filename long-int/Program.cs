using System;
using System.Collections.Generic;
using System.IO;

namespace long_int
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            while (true)
            {
                Console.WriteLine("Введите абсолютный путь к файлу:");
                Console.Write(">> ");
                path = Console.ReadLine();
                if (File.Exists(path))
                {
                    Console.WriteLine("Ожидайте завершения рассчетов...");
                    break;
                }
                else
                {
                    Console.WriteLine("Такого файла не существует");
                    Console.WriteLine("");
                }
            }
            
            DateTime start = DateTime.Now;
            string[] readText = File.ReadAllLines(@path);
            long[] numbers = new long[readText.Length];
            long max = numbers[0];
            long min = numbers[0];
            long average = 0;
            long median;
            
            for (int i = 0; i < readText.Length; i++)
            {
                numbers[i] = Convert.ToInt64(readText[i]);
            }
            
            for(int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] > max)
                {
                    max = numbers[i];
                }
                if(numbers[i] < min)
                {
                    min = numbers[i];
                }
                average += numbers[i];
            }
            average = average / numbers.Length;

            List<long> ascendingSequence = getLongestAscendingSequence(numbers);
            List<long> descendingSequence = getLongestDescendingSequence(numbers);

            Array.Sort(numbers);

            if (numbers.Length % 2 == 0)
            {
                median = (numbers[(long)Math.Floor(numbers.Length / 2.0)] + numbers[(long)Math.Ceiling(numbers.Length / 2.0)]) / 2;
            }
            else
            {
                median = numbers[(long)Math.Ceiling(numbers.Length / 2.0)];
            }

            
            Console.WriteLine($"Элементов массива: {numbers.Length}");
            Console.WriteLine($"2.Минимальное: {min}");
            Console.WriteLine($"3.Максимальное: {max}");
            Console.WriteLine($"4.Среднее: {average}");
            Console.WriteLine($"5.Медиана: {median}");
            Console.WriteLine($"6.Высходящая последовательность:");
            foreach (long number in ascendingSequence)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"Нисходящая последовательность:");
            foreach (long number in descendingSequence)
            {
                Console.WriteLine(number);
            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"Время: {end - start}");

            Console.ReadKey();
        }

        private static List<long> getLongestAscendingSequence(long[] numbers)
        {
            List<long> tempSequence = new List<long> { };
            List<long> sequence = new List<long> { };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers.Length - 1
                    && numbers[i] <= numbers[i + 1])
                {
                    tempSequence.Add(numbers[i]);
                }
                else
                {
                    if (tempSequence.Count > sequence.Count)
                    {
                        sequence.Clear();
                        sequence.AddRange(tempSequence);
                    }
                    tempSequence.Clear();
                }
            }

            return sequence;
        }

        private static List<long> getLongestDescendingSequence(long[] numbers)
        {
            List<long> tempSequence = new List<long> { };
            List<long> sequence = new List<long> { };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers.Length - 1
                    && numbers[i] >= numbers[i + 1])
                {
                    tempSequence.Add(numbers[i]);
                }
                else
                {
                    if (tempSequence.Count > sequence.Count)
                    {
                        sequence.Clear();
                        sequence.AddRange(tempSequence);
                    }
                    tempSequence.Clear();
                }
            }

            return sequence;
        }
    }
}
