//You are climbing a staircase. It takes n steps to reach the top.

//Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

//1 <= n <= 45


using NUnit.Framework;

var tests = new[]
{
    (input: 2, output: 2),
    (input: 3, output: 3),
};

foreach (var test in tests)
{
    Assert.That(ClimbStairs(test.input), Is.EqualTo(test.output));
}

// Solution
int ClimbStairs(int n)
    => ClimbStairsImpl(n, 0, new Dictionary<int, int>());


int ClimbStairsImpl(int n, int sum, IDictionary<int, int> cache)
{
    if (sum > n)
    {
        return 0;
    }
    if (sum == n)
    {
        return 1;
    }

    var singleStep = AddOrRetrieve(sum + 1, () => ClimbStairsImpl(n, sum + 1, cache), cache);
    var doubleStep = AddOrRetrieve(sum + 2, () => ClimbStairsImpl(n, sum + 2, cache), cache);
    return singleStep + doubleStep;
}

int AddOrRetrieve(int n, Func<int> get, IDictionary<int, int> cache)
{
    if (cache.TryGetValue(n, out var result))
    {
        return result;
    }

    var calculated = get();
    cache[n] = calculated;
    return calculated;
}