using System;
public class TicTacToe
{
    static void Main(string[] args)
    {
        bool gameStart = false;
        int menuOption = 2;
        do
        {
            menuOption = MenuList();
            if (menuOption == 1)
            {
                gameStart = true;
                break;
            }
        }
        while (menuOption != 0);

        while (gameStart)
        {
            game();
            gameStart = retry();
        }
    }
    static int MenuList()
    {
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. About the author");
        Console.WriteLine("3. Exit");
        int menuButton = Convert.ToInt32(Console.ReadLine());
        if (menuButton == 1)
        {
            Console.Clear();
            return 1;
        }
        else if (menuButton == 2)
        {
            Console.Clear();
            Console.WriteLine("Created by Mykhailenko Vadym!");
            return 2;
        }
        else if (menuButton == 3)
        {
            Console.Clear();
            Console.WriteLine("Are you certain? (y/n)");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                Console.Clear();
                return 0;
            }
            else
            {
                Console.Clear();
                return 2;
            }
        }
        else return 2;
    }

    static void game()
    {
        //Initialisation
        string[] yFirst = { " ", " ", " " };
        string[] ySecond = { " ", " ", " " };
        string[] yThird = { " ", " ", " " };
        string[][] Board = { yFirst, ySecond, yThird };
        string player = "X";
        int turns = 0;


        //Game Finish Check
        while (true)
        {
            Console.Clear();

            //Board
            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                Console.WriteLine($" {Board[boxRow][0]} | {Board[boxRow][1]} | {Board[boxRow][2]} ");
                if (boxRow < 2) Console.WriteLine("---+---+---");
            }

            //Win Check
            if (winCheck(Board, turns)) break;

            //Player's turn
            Console.Write($"{player}’s move > ");
            int Act = Convert.ToInt32(Console.ReadLine());
            Act -= 1;

            //In range?
            if (Act > -1 && Act < 9)
            {
                int selRow = 0;
                while (Act > 2)
                {
                    Act -= 3;
                    selRow++;
                }
                if (Board[selRow][Act] == " ")
                {
                    Board[selRow][Act] = player;
                    if (player == "X")
                    {
                        player = "O";
                    }
                    else player = "X";
                    turns++;
                }
            }
        }
    }

    static bool winCheck(string[][] table, int finalTurn)
    {
        for (int i = 0; i < table.Length; i++)
        {
            //Vertical
            if (table[i][0] != " " && table[i][0] == table[i][1] && table[i][1] == table[i][2])
            {
                Console.WriteLine($"{table[i][0]} is victorious!");
                return true;
            }
            //Horizontal
            else if (table[0][i] != " " && table[0][i] == table[1][i] && table[1][i] == table[2][i])
            {
                Console.WriteLine($"{table[0][i]} is victorious!");
                return true;
            }
            //Diagonal 1
            else if (table[0][0] != " " && table[0][0] == table[1][1] && table[1][1] == table[2][2])
            {
                Console.WriteLine($"{table[0][i]} is victorious!");
                return true;

            }
            //Diagonal 2
            else if (table[0][2] != " " && table[0][2] == table[1][1] && table[1][1] == table[2][0])
            {
                Console.WriteLine($"{table[0][i]} is victorious!");
                return true;
            }
        }
        //Tie?
        if (finalTurn == 9)
        {
            Console.WriteLine("Tie!");
            return true;
        }
        else return false;
    }

    static bool retry()
    {
        while (true)
        {
            Console.WriteLine("Try Again? (y/n)");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                return true;
            }
            else if (ans == "n")
            {
                return false;
            }
        }
    }
}
