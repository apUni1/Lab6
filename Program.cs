using Lab6;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace apLab6;

/// <summary>
/// Главный класс программы, содержащий точку входа и меню приложения
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа в приложение. Отображает меню
    /// </summary>
    public static void Main()
    {
        bool menuRun = true;
        while (menuRun)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------ МЕНЮ ------");
            Console.ResetColor();
            Console.WriteLine("1. Отгадай ответ");
            Console.WriteLine("2. Об авторе");
            Console.WriteLine("3. Сортировка массивов");
            Console.WriteLine("4. Игра");
            Console.WriteLine("5. Выход");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------");
            Console.ResetColor();
            string phrase = "Выберите действие: ";
            double choice = InputControl.UserAnswer(phrase);


            switch (choice)
            {

                case 1:
                    GuessGame.GuessGameMain();
                    break;

                case 2:
                    Author();
                    break;

                case 3:
                    ArraysWork ar1 = new ArraysWork();
                    int len = InputControl.BoxLength();
                    ArraysWork ar2 = new ArraysWork(len);
                    break;

                case 4:
                    MagicRectangle game = new MagicRectangle();
                    game.MagicSquareMain();
                    break;

                case 5:
                    if (ExitControl()) menuRun = false;
                    break;

            }
        }
    }

    /// <summary>
    /// Выводит информацию об авторе
    /// </summary>
    static void Author()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---------- Об авторе -----------");
        Console.ResetColor();
        Console.WriteLine("ФИО: Пеганова Анна Станиславовна");
        Console.WriteLine("Группа: 6104-090301D");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------");
        Console.ResetColor();
        Console.WriteLine("Для возвращения в главное меню нажмите любую клавишу.");
        Console.ReadLine();
    }


    /// <summary>
    /// Прроизводит выход из приложения
    /// </summary>
    /// <returns>Ответ пользователя: "д"(true) или "н"(false)</returns>
    static bool ExitControl()
    {

        Console.Clear();
        bool exitRun = true;
        bool ans = false;
        while (exitRun)
        {
            Console.Write("Хотите выйти из программы? (д - да, н - нет): ");
            string exitOrNot = Console.ReadLine()?.ToLower();

            if (exitOrNot == "д")
            {
                ans = true;
                exitRun = false;
            }
            else if (exitOrNot == "н")
            {
                ans = false;
                exitRun = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод данных. Введите 'д' или 'н'");
                Console.ResetColor();
            }
        }
        return ans;
    }

}
