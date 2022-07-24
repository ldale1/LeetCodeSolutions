//Write a program to solve a Sudoku puzzle by filling the empty cells.

//A sudoku solution must satisfy all of the following rules:

//Each of the digits 1-9 must occur exactly once in each row.
//Each of the digits 1-9 must occur exactly once in each column.
//Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
//The '.' character indicates empty cells.

using NUnit.Framework;

var tests = new[]
{
    (input: new char[][] {
        new char[] {'5','3','.','.','7','.','.','.','.'},
        new char[] {'6','.','.','1','9','5','.','.','.'},
        new char[] {'.','9','8','.','.','.','.','6','.'},
        new char[] {'8','.','.','.','6','.','.','.','3'},
        new char[] {'4','.','.','8','.','3','.','.','1'},
        new char[] {'7','.','.','.','2','.','.','.','6'},
        new char[] {'.','6','.','.','.','.','2','8','.'},
        new char[] {'.','.','.','4','1','9','.','.','5'},
        new char[] {'.','.','.','.','8','.','.','7','9'}
    },
    output: new char[][] {
        new char[] {'5','3','4','6','7','8','9','1','2'},
        new char[] {'6','7','2','1','9','5','3','4','8'},
        new char[] {'1','9','8','3','4','2','5','6','7'},
        new char[] {'8','5','9','7','6','1','4','2','3'},
        new char[] {'4','2','6','8','5','3','7','9','1'},
        new char[] {'7','1','3','9','2','4','8','5','6'},
        new char[] {'9','6','1','5','3','7','2','8','4'},
        new char[] {'2','8','7','4','1','9','6','3','5'},
        new char[] {'3','4','5','2','8','6','1','7','9'}
    }),
};

char blank = '.';
char[] chars = new char[] { '5', '3', '4', '6', '7', '8', '9', '1', '2' };


foreach (var test in tests)
{
    var solved = SolveSudoku(test.input);
    Assert.That(solved, Is.True);
    Assert.That(test.input, Is.EqualTo(test.output));
}

// Solution
bool SolveSudoku(char[][] board)
{
    for (int row = 0; row < 9; row++)
    {
        for (int col = 0; col < 9; col++)
        {
            var digit = board[row][col];
            if (digit != blank)
            {
                continue;
            }

            foreach (var num in chars)
            {
                if (!IsValid(board, row, col, num))
                {
                    continue;
                }

                // Set it
                board[row][col] = num;

                // Go on with the new board state
                if (SolveSudoku(board))
                {
                    return true;
                }

                // Back track
                board[row][col] = blank;
            }

            // Couldn't find something which worked
            return false;
        }
    }

    // No empty spaces
    return true;
}


bool IsValid(char[][] board, int row, int col, char test)
{
    var gridRow0 = 3 * (row / 3);
    var gridCol0 = 3 * (col / 3);

    for (int i = 0; i < 9; i++)
    {
        if (board[row][i] == test)
        {
            return false;
        }

        if (board[i][col] == test)
        {
            return false;
        }

        var gridRow = gridRow0 + i / 3;
        var gridCol = gridCol0 + i % 3;
        if (board[gridRow][gridCol] == test)
        {
            return false;
        }
    }
    return true;
}
}}