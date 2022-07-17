//Given a string s, find the length of the longest substring without repeating characters.

//0 <= s.length <= 5 * 104
//s consists of English letters, digits, symbols and spaces.


using NUnit.Framework;

var tests = new[]
{
    (input: "dvdf", longest: 3), // "vdf"
    (input: "abcabcbb", longest: 3), // "abc"
    (input: "abcbdea", longest: 5), // "cbdea"
    (input: "bbbbb", longest: 1), // "b"
    (input: "pwwkew", longest: 3), // "wke"
};

foreach (var test in tests)
{
    Assert.That(LengthOfLongestSubstring(test.input), Is.EqualTo(test.longest));
}

// Solution
int LengthOfLongestSubstring(string s)
{
    int longest = 0, start = 0;
    var characters = new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++)
    {
        var character = s[i];
        if (characters.TryGetValue(character, out var lastOccurrence) && lastOccurrence >= start)
        {
            longest = Math.Max(longest, i - start);
            start = lastOccurrence + 1;
        }

        characters[character] = i;
    }

    longest = Math.Max(longest, s.Length - start);
    return longest;
}