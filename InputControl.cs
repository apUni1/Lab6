using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Класс, содержащий методы для проверки вводимых данных (чисел)
    /// </summary>
    static class InputControl
    {
        /// <summary>
        /// Выводит сообщения и проверяет ввод целого числа
        /// </summary>
        /// <param name="phrase">Сообщение для пользователя</param>
        /// <returns>Целое число</returns>
        public static int UserAnswer(string phrase)
        {
            bool ask = true;
            int res = 0;
            while (ask)
            {
                Console.Write(phrase);
                string nums = Console.ReadLine();
                if (int.TryParse(nums, out int num))
                {
                    res = num;
                    ask = false;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                    Console.ResetColor();
                }

            }
            return res;
        }

        /// <summary>
        /// Получает координаты места на поле с проверкой на то, что клетка свободна
        /// </summary>
        /// <param name="board">Игровое поле</param>
        /// <param name="onBoard">Числа, которые уже выставлены на игровое поле</param>
        /// <returns>Координаты места на поле</returns>
        public static int[] GetPlace(int[,] board, int[] onBoard)
        {
            bool ask = true;
            int[] res = new int[2];
            while (ask)
            {
                Console.Write("\nВыберите строку: ");
                int num1 = 0;
                while (ask)
                {
                    string nums = Console.ReadLine();
                    if (int.TryParse(nums, out num1) && num1 > 0 && num1 < 4)
                    {
                        switch (num1)
                        {
                            case 1:
                                if (onBoard[0] == 0 || onBoard[1] == 0 || onBoard[2] == 0)
                                {
                                    res[0] = num1;
                                    ask = false;
                                }
                                break;
                            case 2:
                                if (onBoard[3] == 0 || onBoard[4] == 0 || onBoard[5] == 0)
                                {
                                    res[0] = num1;
                                    ask = false;
                                }
                                break;
                            case 3:
                                if (onBoard[6] == 0 || onBoard[7] == 0 || onBoard[8] == 0)
                                {
                                    res[0] = num1;
                                    ask = false;
                                }
                                break;
                            default:
                                Console.WriteLine("Данная строка заполнена. Выберите другую");
                                break;
                        }


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                Console.Write("\nВыберите столбец: ");
                ask = true;
                int num2 = 0;

                while (ask)
                {
                    string nums = Console.ReadLine();
                    if (int.TryParse(nums, out num2) && num2 > 0 && num2 < 4)
                    {
                        switch (num2)
                        {
                            case 1:
                                if (onBoard[0] == 0 || onBoard[3] == 0 || onBoard[6] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            case 2:
                                if (onBoard[1] == 0 || onBoard[4] == 0 || onBoard[7] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            case 3:
                                if (onBoard[2] == 0 || onBoard[5] == 0 || onBoard[8] == 0)
                                {
                                    res[1] = num2;
                                    ask = false;
                                }
                                break;
                            default:
                                Console.WriteLine("Данный столбец заполнен. Выберите другой.");
                                break;
                        }


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                }
                if (board[res[0] - 1, res[1] - 1] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данное место занято. Выберите другое.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ask = true;
                }
            }
            return res;
        }

        /// <summary>
        /// Получает число, которе пользователь хочет выставить на поле с проверкой на то, что это число ещё не выставлено на игровое поле
        /// </summary>
        /// <param name="avNums">Числа, которые доступны пользователю</param>
        /// <returns>Число, которе пользователь хочет выставить на поле</returns>
        public static int GetNumber(int[] avNums)
        {
            Console.Write("\nВыберите число: ");
            bool ask = true;
            int num = 0;
            int res = 0;
            while (ask)
            {
                string nums = Console.ReadLine();
                if (int.TryParse(nums, out num))
                {
                    if (Array.IndexOf(avNums, num) != -1 && num != 0)
                    {
                        res = num;
                        ask = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ведите число из списка доступных чисел.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод данных. Попробуйте ещё раз.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            return res;
        }


        /// <summary>
        /// Запрашивает длину массива у пользователя
        /// </summary>
        /// <returns>Длина массива</returns>

        public static int BoxLength()
        {
            int ans = 0;
            bool ask = true;
            while (ask)
            {
                string phrase = "Введите длину массива: ";
                int len = UserAnswer(phrase);
                if (len > 0)
                {
                    ans = len;
                    ask = false;
                }
            }
            return ans;
        }
    }
}
