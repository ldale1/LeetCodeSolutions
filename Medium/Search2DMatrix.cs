//Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

//Integers in each row are sorted from left to right.
//The first integer of each row is greater than the last integer of the previous row.


using NUnit.Framework;

var tests = new[]
{
    (input: new int[][] { new int[] {1, 3, 5, 7}, new int[] {10, 11, 16, 20}, new int[] {23, 30, 34, 60}}, target: 3, output: true),
    (input: new int[][] { new int[] {1, 3, 5, 7}, new int[] {10, 11, 16, 20}, new int[] {23, 30, 34, 60}}, target: 12, output: false)
};

foreach (var test in tests)
{ 
    Assert.That(SearchMatrix(test.input, test.target), Is.EqualTo(test.output));
}

// Solution
bool SearchMatrix(int[][] matrix, int target)
{
    int n = matrix.Length;
    if (n == 0)
    {
        return false;
    }

    int m = matrix[0].Length;
    if (m == 0)
    {
        return false;
    }

    int start = 0;
    int end = m * n - 1;

    while (start != end)
    {
        var mid = (start + end) / 2;

        var number = GetNumber(mid);
        if (number < target)
        {
            start = mid + 1;
        }
        else
        {
            end = mid;
        }
    };

    return GetNumber(end) == target;

    int GetNumber(int flatIndex)
    {
        int i = flatIndex / m;
        int j = flatIndex % m;
        return matrix[i][j];
    }
}