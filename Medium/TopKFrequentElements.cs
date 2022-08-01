//Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
//1 <= nums.length <= 105
//-104 <= nums[i] <= 104
//k is in the range[1, the number of unique elements in the array].
//It is guaranteed that the answer is unique.

using NUnit.Framework;

var tests = new[]
{
    (input: new int[] {1,1,1,2,2,3}, k: 2,  answer: new int[] {1,2}),
    (input: new int[] {1}, k: 1,  answer: new int[] {1}),
};

foreach (var test in tests)
{
    Assert.That(TopKFrequent(test.input, test.k).ToArray(), Is.EquivalentTo(test.answer));
}

// Solution
IEnumerable<int> TopKFrequent(int[] nums, int k)
{
    var frequencies = new Dictionary<int, int>();
    foreach (var num in nums)
    {
        frequencies[num] = frequencies.TryGetValue(num, out var count) 
            ? count + 1 
            : 1;
    }

    var ordering = new PriorityQueue<int, int>();
    foreach (var (num, hits) in frequencies)
    {
        ordering.Enqueue(num, -hits);
    }

    for (int i = 0; i < k; i++)
    {
        yield return ordering.Dequeue();
    }
}