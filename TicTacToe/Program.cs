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
        static char currentPlayer = 'X';
        static void Main(string[] args)
        {
            InitializeBoard();

            while (true)
            {
                DrawBoard();
                Console.WriteLine($"Ход игрока {currentPlayer}");

                Console.Write("Введите строку (1-3): ");
                int row = int.Parse(Console.ReadLine());

                Console.Write("Введите столбец (1-3): ");
                int col = int.Parse(Console.ReadLine());

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
                    break;
                }

                if (CheckDraw())
                {
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    break;
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }

            Console.ReadKey();
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
    }
}
       