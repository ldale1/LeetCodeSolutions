//Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

//The overall run time complexity should be O(log (m+n)).

//nums1.length == m
//nums2.length == n
//0 <= m <= 1000
//0 <= n <= 1000
//1 <= m + n <= 2000
//- 106 <= nums1[i], nums2[i] <= 106

using NUnit.Framework;

var tests = new[]
{
    (
        nums1: new [] {1, 3},
        nums2: new [] {2},
        median: 2.0
    ),
    (
        nums1: new [] {1, 2},
        nums2: new [] {3, 4},
        median: 2.5
    ),
};

foreach (var test in tests)
{
    Assert.That(FindMedianSortedArrays(test.nums1, test.nums2), Is.EqualTo(test.median));
}

// Solution
double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    // Move along the two arrays in asending order, tracking the current and previous.
    // When x iterations are hit these will decide the median.
    // Doesn't quite hit the log(m+n) requirement probably needs binary search somewhere
    var previous = 0.0;
    var current = 0.0;

    // head indices
    var head1 = 0;
    var head2 = 0;

    var total = (nums1.Length + nums2.Length);
    var iterations = total / 2 + 1;
    for (var i = 0; i < iterations; i++)
    {
        var num1 = head1 < nums1.Length 
            ? nums1[head1] 
            : double.MaxValue;
        var num2 = head2 < nums2.Length 
            ? nums2[head2] 
            : double.MaxValue;

        // Find which is array is greater and move along
        var temp = current;
        current = num1 < num2
            ? nums1[head1++]
            : nums2[head2++];

        previous = temp;
    }

    // If there are an even amount of elements, find the average of previous and current
    return total % 2 == 0
        ? (previous + current) / 2.0
        : current;
}