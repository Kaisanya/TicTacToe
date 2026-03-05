//Автор: Агеева Альбина Викторовна. 
//Группа: ИСП(9)-23-1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static char[,] board = new char[4, 4];
        static char playerX = 'X';
        static char playerO = 'O';

        static int scoreX = 0;
        static int scoreO = 0;

        static char currentPlayer;

        static void Main(string[] args)
        {
            CustomizeSymbols();

            while (true)
            {
                InitializeBoard();
                currentPlayer = playerX;

                while (true)
                {
                    DrawBoard();
                    Console.WriteLine($"Ход игрока {currentPlayer}");

                    int row, col;

                    Console.Write("Введите строку (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out row))
                        continue;

                    Console.Write("Введите столбец (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out col))
                        continue;

                    if (row < 1 || row > 3 || col < 1 || col > 3)
                        continue;

                    if (board[row, col] != ' ')
                    {
                        Console.WriteLine("Клетка занята!");
                        continue;
                    }

                    board[row, col] = currentPlayer;

                    if (CheckWin())
                    {
                        DrawBoard();
                        Console.WriteLine($"Игрок {currentPlayer} победил!");

                        if (currentPlayer == playerX)
                            scoreX++;
                        else
                            scoreO++;

                        break;
                    }

                    if (CheckDraw())
                    {
                        DrawBoard();
                        Console.WriteLine("Ничья!");
                        break;
                    }

                    currentPlayer = currentPlayer == playerX ? playerO : playerX;
                }

                ShowScore();

                Console.WriteLine("Играть снова? (y/n)");
                string answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                    break;

                Console.WriteLine("Хотите изменить символы? (y/n)");
                answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                    CustomizeSymbols();
            }
        }

        static void CustomizeSymbols()
        {
            Console.Write("Введите символ для игрока 1: ");
            playerX = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Введите символ для игрока 2: ");
            playerO = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }

        static void InitializeBoard()
        {
            for (int i = 1; i < 4; i++)
                for (int j = 1; j < 4; j++)
                    board[i, j] = ' ';
        }

        static void DrawBoard()
        {
            Console.Clear();

            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine($"{board[i, 1]} | {board[i, 2]} | {board[i, 3]}");
                if (i < 3)
                    Console.WriteLine("---------");
            }
        }

        static bool CheckWin()
        {
            for (int i = 1; i < 4; i++)
            {
                if (board[i, 1] == currentPlayer &&
                    board[i, 2] == currentPlayer &&
                    board[i, 3] == currentPlayer)
                    return true;

                if (board[1, i] == currentPlayer &&
                    board[2, i] == currentPlayer &&
                    board[3, i] == currentPlayer)
                    return true;
            }

            if (board[1, 1] == currentPlayer &&
                board[2, 2] == currentPlayer &&
                board[3, 3] == currentPlayer)
                return true;

            if (board[1, 3] == currentPlayer &&
                board[2, 2] == currentPlayer &&
                board[3, 1] == currentPlayer)
                return true;

            return false;
        }

        static bool CheckDraw()
        {
            foreach (char c in board)
                if (c == ' ')
                    return false;

            return true;
        }

        static void ShowScore()
        {
            Console.WriteLine();
            Console.WriteLine("Счёт:");
            Console.WriteLine($"Игрок 1 ({playerX}) — {scoreX}");
            Console.WriteLine($"Игрок 2 ({playerO}) — {scoreO}");
        }
    }
}
