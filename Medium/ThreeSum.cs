// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

// Notice that the solution set must not contain duplicate triplets.

// 3 <= nums.length <= 3000
// -105 <= nums[i] <= 105

using NUnit.Framework;
using System.Text;

var tests = new[]
{
    (input: new [] { -1, 0, 1, 2, -1, -4 }, output: new int[][] { new [] { -1, -1, 2 }, new [] { -1, 0, 1 }}),
    (input: new [] { -2, 1, 1 }, output: new int[][] { new [] { -2, 1, 1 } })
};

foreach (var test in tests)
{
    Assert.That(ThreeSum(test.input), Is.EquivalentTo(test.output));
}

// Solution
IList<IList<int>> ThreeSum(int[] nums)
{
    nums = nums.OrderBy(x => x).ToArray();
     
    var result = new List<IList<int>>();
    for (int i = 0; i < nums.Length - 2; i++)
    {
        var first = nums[i];
        if (first > 0)
        {
            break;
        }
        if (i != 0 && first == nums[i - 1])
        {
            continue;
        }

        var left = i + 1;
        var right = nums.Length - 1;

        do
        {
            var second = nums[left];
            var third = nums[right];
            var sum = second + third;
            if (sum > -first)
            {
                --right;
            }
            else if (sum < -first)
            {
                ++left;
            }
            else
            {
                result.Add(new List<int>() { first, second, third });

                while (left < right && nums[left] == nums[++left]) { }
                while (left < right && nums[right] == nums[--right]) { }
            }
        } while (left < right);
    }

    return result;
}