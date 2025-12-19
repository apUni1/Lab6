using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Реализует игру "Угадай ответ" с математической функцией
    /// </summary>
    static class GuessGame
    {
        /// <summary>
        /// Запускает игру "Угадай ответ"
        /// </summary>
        public static void GuessGameMain()
        {
            Console.Clear();
            double a = 0;
            double b = 0;
            bool takeA = true;
            bool takeB = true;
            while (takeA)
            {
                string phrase1 = "Введите значение для переменной a: ";
                a = (double)InputControl.UserAnswer(phrase1);
                if (Math.Abs(3 * Math.PI / 4 + a / 3) > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данное число не подойдёт для вычислений. Попробуйте ещё раз.");
                    Console.ResetColor();
                }
                else takeA = false;

            }
            while (takeB)
            {
                string phrase2 = "Введите значение для переменной b: ";
                b = (double)InputControl.UserAnswer(phrase2);
                if (Math.Cos(b) < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данное число не подойдёт для вычислений. Попробуйте ещё раз.");
                    Console.ResetColor();
                }
                else takeB = false;
            }

            double correctAnswer = Func(a, b);
            GuessControl(correctAnswer);

            Console.WriteLine("Для возвращения в главное меню нажмите любую клавишу.");
            Console.ReadKey();
        }

        /// <summary>
        /// Вычисляет правильный ответ по формуле
        /// </summary>
        /// <param name="a">Число для произведения вычислений</param>
        /// <param name="b">Число для произведения вычислений</param>
        /// <returns>Правильный ответ</returns>
        static double Func(double a, double b)
        {
            double correctAnswer = Math.Round(Math.Pow(Math.Sin(3 * Math.PI / 4 + a / 3), 2) + Math.Sqrt(Math.Cos(b)));
            return correctAnswer;
        }

        /// <summary>
        /// Сверяет ответ пользователя с правильным и обЪвляет победу или поражение
        /// </summary>
        /// <param name="correctAnswer">Правильный ответ</param>
        static void GuessControl(double correctAnswer)
        {
            const int attempts = 3;
            int attemptsLeft = attempts;
            bool goodGuess = false;
            string phrase = "Ваша догадка: ";
            while (attemptsLeft > 0 && !goodGuess)
            {
                Console.WriteLine($"Количество оставшихся попыток: {attemptsLeft} ");
                double userGuess = InputControl.UserAnswer(phrase);


                userGuess = Math.Round(userGuess, 2);
                if (userGuess == correctAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ответ верный! Вы победили!");
                    Console.ResetColor();
                    goodGuess = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ответ неверный.");
                    Console.ResetColor();
                    attemptsLeft--;
                }

            }

            if (!goodGuess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Вы проиграли. Правильный ответ: {correctAnswer}");
                Console.ResetColor();
            }
        }
    }
}
