//Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.

//You have the following three operations permitted on a word:

//Insert a character
//Delete a character
//Replace a character

//0 <= word1.length, word2.length <= 500
//word1 and word2 consist of lowercase English letters.

using NUnit.Framework;

var tests = new[]
{
    (word1: "horse", word2: "ros", output: 3),
    (word1: "intention", word2: "execution", output: 5),
};
foreach (var test in tests)
{
    Assert.That(MinDistance(test.word1, test.word2), Is.EqualTo(test.output));
}

// Solution
int MinDistance(string word1, string word2)
{
    var cache = new Dictionary<(int, int), int>();
    return MinDistanceImpl(0, 0);

    int MinDistanceImpl(int i, int j)
    {
        var answer = () =>
        {
            if (word1.Length == i && word2.Length == j)
            {
                return 0;
            }
            if (word1.Length == i && word2.Length != j)
            {
                return word2.Length - j;
            }
            if (word1.Length != i && word2.Length == j)
            {
                return word1.Length - i;
            }
            if (word1[i] == word2[j])
            {
                return MinDistanceImpl(i + 1, j + 1);
            }

            var add = MinDistanceImpl(i, j + 1);
            var remove = MinDistanceImpl(i + 1, j);
            var replace = MinDistanceImpl(i + 1, j + 1);
            return 1 + Math.Min(Math.Min(add, remove), replace);
        };

        return AddOrRetrieve((i, j), answer, cache);
    }
}

R AddOrRetrieve<T, R>(T key, Func<R> get, IDictionary<T, R> cache)
{
    if (cache.TryGetValue(key, out var result))
    {
        return result;
    }

    var calculated = get();
    cache[key] = calculated;
    return calculated;
}