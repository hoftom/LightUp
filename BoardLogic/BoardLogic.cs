namespace BoardLogic
{
    class BoardLogic
    {
        static char[,] board;
        static int boardSize = 5;
        static int maxTries = 10;
        static int tries = 0;

        static void InitializeBoard()
        {
            board = new char[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void PrintBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void LightCell(int row, int col)
        {
            if (row >= 0 && row < boardSize && col >= 0 && col < boardSize)
            {
                if (board[row, col] == ' ')
                {
                    board[row, col] = '*';
                }
                else if (board[row, col] == '*')
                {
                    board[row, col] = ' ';
                }
            }
        }

        static bool IsGameComplete()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (board[i, j] == '*')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            InitializeBoard();

            Console.WriteLine("Welcome to the Lightup Game!");
            Console.WriteLine("Toggle lights to solve the puzzle.");
            Console.WriteLine("Enter row and column (e.g., 1 2) to toggle a light.");

            while (tries < maxTries)
            {
                Console.WriteLine($"Attempt {tries + 1}/{maxTries}");
                PrintBoard();

                Console.Write("Enter row and column: ");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Use format: row col");
                    continue;
                }

                if (int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    row--; // Adjust for 0-based indexing
                    col--; // Adjust for 0-based indexing
                    LightCell(row, col);

                    if (IsGameComplete())
                    {
                        Console.WriteLine("Congratulations! You solved the puzzle.");
                        break;
                    }

                    tries++;
                }
                else
                {
                    Console.WriteLine("Invalid input. Use format: row col");
                }
            }

            if (tries >= maxTries)
            {
                Console.WriteLine("Out of attempts. Game over.");
            }
        }
    }
}