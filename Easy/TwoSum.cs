//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.

using NUnit.Framework;

var tests = new[]
{
    new
    {
        Nums = new[] { 2, 7, 11, 15 },
        Target = 9,
        Expected =  new [] { 1, 0 },
    },
    new
    {
        Nums = new[] { 1, 2, 1, 2 },
        Target = 4,
        Expected =  new [] { 1, 3 },
    },
};

foreach (var test in tests)
{
    Assert.That(TwoSum(test.Nums, test.Target), Is.EquivalentTo(test.Expected));
}


int[] TwoSum(int[] nums, int target)
{
    var numberIndices = nums
        .Select((Number, Index) => (Number, Index))
        .GroupBy(numInd => numInd.Number)
        .ToDictionary(
            g => g.Key, 
            g => g.Select(numInd => numInd.Index).ToArray()
        );

    for (int firstIndex = 0; firstIndex < nums.Length; firstIndex++)
    {
        if (!numberIndices.TryGetValue(target - nums[firstIndex], out var indices))
        {
            continue;
        }

        foreach (var secondIndex in indices)
        {
            if (firstIndex != secondIndex)
            {
                return new[] { firstIndex, secondIndex };
            }
        }
    }

    throw new InvalidOperationException();
}
