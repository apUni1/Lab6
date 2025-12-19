using Lab6;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Класс для работы с массивами
    /// </summary>
    class ArraysWork
    {
        private int _len;
        private int[] _box;

        /// <summary>
        /// Конструктор по умолчанию, создает массив длиной 10 элементов
        /// </summary>
        public ArraysWork()
        {
            _len = 10;
            _box = BoxMaker(_len);
            Box();
        }

        /// <summary>
        /// Конструктор с параметром для создания массива заданной длины
        /// </summary>
        /// <param name="l">Длина создаваемого массива</param>
        public ArraysWork(int l)
        {
            _len = l;
            _box = BoxMaker(_len);
            Box();
        }

        /// <summary>
        /// Создаёт копии массива, сортирует массивы и выводит на экран
        /// </summary>
        public void Box()
        {
            Console.Clear();
            int[] copyBox1 = CopyMaker(_box);
            int[] copyBox2 = CopyMaker(_box);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Заданный массив: ");
            Console.ResetColor();
            ShowBox(_box);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nОтсортированный массив 1: ");
            Console.ResetColor();
            int[] sortedBox1 = GnomeSort(copyBox1);
            ShowBox(sortedBox1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nОтсортированный массив 2: ");
            Console.ResetColor();
            int[] sortedBox2 = MixSort(copyBox2);
            ShowBox(sortedBox2);

            Console.WriteLine("\nДля возвращения в главное меню нажмите любую клавишу.");
            Console.ReadKey();
        }



        /// <summary>
        /// Создаёт массив
        /// </summary>
        /// <param name="len">Длина массива</param>
        /// <returns>Массив чисел</returns>
        private int[] BoxMaker(int len)
        {
            int i = 0;
            Random randomNumbers = new Random();
            int[] numbers = new int[len];
            while (i < len)
            {
                numbers[i] = randomNumbers.Next();
                i++;
            }
            return numbers;
        }

        /// <summary>
        /// Создаёт копию массива
        /// </summary>
        /// <param name="box">Массив, который нужно копировать</param>
        /// <returns>Копия массива</returns>
        private int[] CopyMaker(int[] box)
        {
            int[] boxCopy = new int[box.Length];
            for (int i = 0; i < box.Length; i++)
            {
                boxCopy[i] = box[i];
            }
            return boxCopy;
        }

        /// <summary>
        /// Выводит массив на экран
        /// </summary>
        /// <param name="box">Массив, который нужно вывести на экран</param>
        private void ShowBox(int[] box)
        {
            if (box.Length > 10) Console.WriteLine("Массивы не могут быть выведены на экран, так как длина массива больше 10.");
            else
            {
                int i = 0;
                for (; i < box.Length; i++)
                {
                    Console.Write($"{box[i]} ");
                }
            }
        }

        /// <summary>
        /// Выполняет гномью сортировку
        /// </summary>
        /// <param name="box">Массив, который нужно отсортировать</param>
        /// <returns>Отсортированный массив</returns>
        private int[] GnomeSort(int[] box)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int i = 1;
            while (i < box.Length)
            {
                if (box[i - 1] < box[i])
                {
                    i++;
                }
                else
                {
                    int swp = box[i - 1];
                    box[i - 1] = box[i];
                    box[i] = swp;
                    --i;

                    if (i == 0)
                    {
                        i++;
                    }
                }
            }
            time.Stop();
            Console.WriteLine($"Время сортировки: {time.ElapsedMilliseconds} мс");
            return box;
        }

        /// <summary>
        /// Выполняет гномью перемешиванием
        /// </summary>
        /// <param name="box">Массив, который нужно отсортировать</param>
        /// <returns>Отсортированный массив</returns>
        private int[] MixSort(int[] box)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int start = 0;
            int end = box.Length - 1;
            while (start < end)
            {
                for (int i = start; i < end; i++)
                {
                    if (box[i] > box[i + 1])
                    {
                        int swp = box[i];
                        box[i] = box[i + 1];
                        box[i + 1] = swp;
                    }
                }
                end--;

                for (int i = end; i > start; i--)
                {
                    if (box[i - 1] > box[i])
                    {
                        int swp = box[i - 1];
                        box[i - 1] = box[i];
                        box[i] = swp;
                    }
                }
                start++;
            }
            time.Stop();
            Console.WriteLine($"Время сортировки: {time.ElapsedMilliseconds} мс");
            return box;
        }
    }
}
