using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    /// <summary>
    /// Класс, содержащий методы для игры "Магический квадрат"
    /// </summary>
    class MagicRectangle
    {
        private const int boardSize = 3;

        /// <summary>
        /// Запускает игру "Магический Квадрат"
        /// </summary>
        public void MagicSquareMain()
        {

            Console.Clear();
            int count = 0;
            bool endgame = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("МАГИЧЕСКИЙ КВАДРАТ");
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine(" --- --- --- ");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] availableNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[,] board = GameBoard();
            int[] onBoard = new int[9];
            while (!endgame)
            {
                endgame = Turn(board, availableNumbers, onBoard);
                count++;
                GameBoardNow(board);
                if (count == 9)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы победили!");
                    Console.ResetColor();
                    Console.ReadKey();
                    endgame = true;
                }
            }
            return;
        }
        /// <summary>
        /// Создаёт массив для хранения чисел на игровом поле
        /// </summary>
        /// <returns>Массив для хранения чисел на игровом поле</returns>
        private int[,] GameBoard()
        {
            int[,] board = new int[3, 3];
            return board;
        }

        /// <summary>
        /// Выводит текущее состояние игрового поля
        /// </summary>
        /// <param name="board">Числа на игровом поле</param>
        private void GameBoardNow(int[,] board)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine($"| {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |");
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine($"| {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |");
            Console.WriteLine(" --- --- --- ");
            Console.WriteLine($"| {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |");
            Console.WriteLine(" --- --- --- ");


        }

        /// <summary>
        /// Проверяет числа, которые остались, выводит доступные числа, проверяет сумму чисел
        /// </summary>
        /// <param name="board">Числа на игровом поле</param>
        /// <param name="avNums">Числа, которые доступны пользователю</param>
        /// <param name="board">Числа, которые выставлены на игровое поле</param>
        /// <returns>Проигрыш(true) или продолжение игры/выйгрыш(false)</returns>
        private bool Turn(int[,] board, int[] avNums, int[] onBoard)
        {
            int num = 0;
            for (int i = 0; i < avNums.Length; i++)
            {
                if (Array.IndexOf(onBoard, avNums[i]) != -1)
                {
                    avNums[i] = 0;
                }
            }
            Console.Write("Доступные числа:");
            for (int i = 0; i < avNums.Length; i++)
            {
                if (avNums[i] != 0) Console.Write($" {avNums[i]}");
            }
            num = InputControl.GetNumber(avNums);
            int[] place = InputControl.GetPlace(board, onBoard);
            int line = place[0];
            int column = place[1];
            board[line - 1, column - 1] = num;
            onBoard[line + column] = num;

            int[] lines = { board[0, 0] + board[0, 1] + board[0, 2], board[1, 0] + board[1, 1] + board[1, 2], board[2, 0] + board[2, 1] + board[2, 2] };
            int[] columns = { board[0, 0] + board[1, 0] + board[2, 0], board[0, 1] + board[1, 1] + board[2, 1], board[0, 2] + board[1, 2] + board[2, 2] };
            switch (line)
            {
                case 1:
                    if ((board[0, 0] != 0 && board[0, 1] != 0 && board[0, 2] != 0) && lines[0] != 15)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
                case 2:
                    if ((board[1, 0] != 0 && board[1, 1] != 0 && board[1, 2] != 0) && lines[1] != 15)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
                case 3:
                    if ((board[2, 0] != 0 && board[2, 1] != 0 && board[2, 2] != 0) && lines[2] != 15)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
            }
            switch (column)
            {
                case 1:
                    if ((board[0, 0] != 0 && board[1, 0] != 0 && board[2, 0] != 0) && columns[0] != 15)
                    {
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
                case 2:
                    if ((board[0, 1] != 0 && board[1, 1] != 0 && board[2, 1] != 0) && columns[1] != 15)
                    {
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
                case 3:
                    if ((board[0, 2] != 0 && board[1, 2] != 0 && board[2, 2] != 0) && columns[2] != 15)
                    {
                        Console.WriteLine("Числа расставлены неверно. Вы проиграли.");
                        Console.ReadKey();
                        return true;

                    }
                    break;
            }
            return false;

        }
    }
}
