//Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.

//We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

//You must solve this problem without using the library's sort function.
 
//n == nums.length
//1 <= n <= 300
//nums[i] is either 0, 1, or 2.

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