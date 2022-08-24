//Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

//The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

//It is guaranteed that the number of unique combinations that sum up to target is less than 150 combinations for the given input.


using NUnit.Framework;

var tests = new[]
{
    (candidates: new int[] {2,3,6,7}, target: 7, output: new int[][] { new int[] {2,2,3}, new int[] {7} } ),
    (candidates: new int[] {2,3,5}, target: 8, output: new int[][] { new int[] {2,2,2,2}, new int[] {2,3,3}, new int[] {3, 5} } ),
    (candidates: new int[] {2}, target: 1, output: new int[][] { } ),
};
foreach (var test in tests)
{
    var answer = CombinationSum(test.candidates, test.target);
    Assert.That(answer, Is.EquivalentTo(test.output));
}

// Solution
IList<IList<int>> CombinationSum(int[] candidates, int target)
{
    var results = new List<IList<int>>();
    CombinationSumImpl(candidates.OrderBy(x => x).ToArray(), Enumerable.Empty<int>(), target, 0);
    return results;

    void CombinationSumImpl(int[] candidates, IEnumerable<int> buildup, int remaining, int index)
    {
        for (int i = index; i < candidates.Length; i++)
        {
            var candidate = candidates[i];
            var nextRemaining = remaining - candidate;
            if (nextRemaining < 0)
            {
                break;
            }

            var nextBuildup = buildup.Append(candidate);
            if (nextRemaining == 0)
            {
                results.Add(nextBuildup.ToList());
                break;
            }

            CombinationSumImpl(candidates, nextBuildup, nextRemaining, i);
        }
    }
}

