//There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

//Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

//The test cases are generated so that the answer will be less than or equal to 2 * 109.

using NUnit.Framework;

var tests = new[]
{
    (m: 3, n: 7, answer: 28),
    (m: 3, n: 2, answer: 3),
};


foreach (var test in tests)
{
    var answer = UniquePaths(test.m, test.n);
    Assert.That(answer, Is.EqualTo(test.answer));
}

// Solution
int UniquePaths(int m, int n)
{
    return UniquePathsImpl(m - 1, n - 1, new int[m,n]);
}

int UniquePathsImpl(int m, int n, int[,] cache)
{
    if (m < 0 || n < 0)
    {
        return 0;
    }
    if (m == 0 && n == 0)
    {
        return 1;
    }

    var cached = cache[m,n];
    if (cached > 0)
    {
        return cached;
    }

    var right = UniquePathsImpl(m -1, n, cache);
    var down = UniquePathsImpl(m, n -1,cache);

    var answer = right + down;
    cache[m, n] = answer;
    return answer;
}
