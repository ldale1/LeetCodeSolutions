//Given an array of strings strs, group the anagrams together. You can return the answer in any order.

//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

//1 <= strs.length <= 104
//0 <= strs{i].length <= 100
//strs[i] consists of lowercase English letters.

using NUnit.Framework;

var tests = new[]
{
    (input: new string[] { "eat","tea","tan","ate","nat","bat" }, 
    answer: new string[][] 
    { 
        new string[] { "bat"}, 
        new string[] { "nat","tan"}, 
        new string[] { "ate","eat","tea"}
    }),
};

foreach (var test in tests)
{
    Assert.That(GroupAnagrams(test.input), Is.EquivalentTo(test.answer).Using<IList<string>, string[]>(AreEqual));
}

// Solution
IList<IList<string>> GroupAnagrams(string[] strs)
{
    var answers = new Dictionary<string, IList<string>>();
    foreach (string str in strs)
    {
        var counts = new char[26];
        foreach (var c in str)
        {
            counts[c - 'a']++;
        }

        var key = new string(counts);
        if (answers.TryGetValue(key, out var existing))
        {
            existing.Add(str);
        }
        else
        {
            answers[key] = new List<string>() { str };
        }
    }
    return answers.Values.ToList();
}

bool AreEqual(IList<string> actual, string[] expected)
    => actual.Count == expected.Length && actual.All(a => expected.Contains(a));