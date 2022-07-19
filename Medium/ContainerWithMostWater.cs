//You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and(i, height[i]).

//Find two lines that together with the x-axis form a container, such that the container contains the most water.

//Return the maximum amount of water a container can store.

//n == height.length
//2 <= n <= 105
//0 <= height[i] <= 104



using NUnit.Framework;

var tests = new[]
{
    (input: new[] {1, 8, 6, 2, 5, 4, 8, 3, 7 }, volume: 49), // 1, 8
    (input: new[] {1, 1 }, volume: 1), // 1, 2

};

foreach (var test in tests)
{
    Assert.That(MaxArea(test.input), Is.EqualTo(test.volume));
}

// Solution
int MaxArea(int[] height)
{
    var left = 0;
    var right = height.Length - 1;
    var max = 0;

    do
    {
        var leftHeight = height[left];
        var rightHeight = height[right];
        var minHeight = Math.Min(leftHeight, rightHeight);

        var volume = (right - left) * minHeight;
        if (leftHeight < rightHeight)
        {
            left += 1;
        }
        else
        {
            right -= 1; 
        }

        max = Math.Max(max, volume);
    } while (left < right);

    return max;

}