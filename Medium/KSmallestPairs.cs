//You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

//Define a pair (u, v) which consists of one element from the first array and one element from the second array.

//Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.

//Constraints:

//1 <= nums1.length, nums2.length <= 105
//- 109 <= nums1[i], nums2[i] <= 109
//nums1 and nums2 both are sorted in ascending order.
//1 <= k <= 104



using NUnit.Framework;

var tests = new[]
{
    (
        nums1: new int[] {1, 3, 11}, 
        nums2: new int[] {2, 4, 6}, 
        k: 3, 
        output: new int[][] { new int[] { 1, 2 }, new int[] { 1, 4 } , new int[] { 3, 2 } }
    ),

};
foreach (var test in tests)
{
    var answers = KSmallestPairs(test.nums1, test.nums2, test.k).ToList();
    Assert.That(answers, Is.EquivalentTo(test.output));
}

// Solution
IEnumerable<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
{
    var queue = new PriorityQueue<(int[] Pair, int Index), int>();
    foreach (var num in nums1)
    {
        queue.Enqueue((Pair: new int[] { num, nums2[0] }, Index: 0), num + nums2[0]);
    }

    for (int i = 0; i < k && queue.Count > 0; i++)
    {
        var (pair, ind) = queue.Dequeue();

        if (++ind < nums2.Length)
        {
            var next = (new int[] { pair[0], nums2[ind] }, ind);
            var prio = pair[0] + nums2[ind];
            queue.Enqueue(next, prio);
        }

        yield return pair;
    }
}

