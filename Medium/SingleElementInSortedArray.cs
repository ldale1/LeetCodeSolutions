//You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once.

//Return the single element that appears only once.

//Your solution must run in O(log n) time and O(1) space.

using NUnit.Framework;

var tests = new[]
{
    (input: new int[] { 1, 1, 2, 3, 3, 4, 4, 8, 8 }, answer: 2),
    (input: new int[] { 3, 3, 7, 7, 10, 11, 11 }, answer: 10),
    (input: new int[] { 1, 2, 2, 3, 3, 4, 4, 8, 8 }, answer: 1),
    (input: new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 8, 8, 9 }, answer: 9),
    (input: new int[] { 1 }, answer: 1),
};


foreach (var test in tests)
{
    var answer = SingleNonDuplicate(test.input);
    Assert.That(answer, Is.EqualTo(test.answer));
}

// Solution
int SingleNonDuplicate(int[] nums)
{
    var low = 0;
    var high = nums.Length - 1;
    while (low < high)
    {
        var mid = (low + high) / 2;
        if (mid % 2 == 1)
        {
            mid -= 1;
        }

        if (nums[mid] != nums[mid + 1])
        {
            high = mid - 1;
        }
        else
        {
            low = mid + 2;
        }
    }

    return nums[low];
}