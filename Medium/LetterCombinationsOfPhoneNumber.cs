//Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

//A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

//0 <= digits.length <= 4
//digits[i] is a digit in the range['2', '9']

using NUnit.Framework;

var tests = new[]
{
    (input: "23", output: new string[] { "ad","ae","af","bd","be","bf","cd","ce","cf"}),
    (input: "", output: new string[] { }),
    (input: "2", output: new string[] { "a","b","c" }),
};


foreach (var test in tests)
{ 
    Assert.That(LetterCombinations(test.input), Is.EquivalentTo(test.output));
}

// Solution
IList<string> LetterCombinations(string digits)
{
    if (string.IsNullOrEmpty(digits))
    {
        return new List<string>();
    }

    var results = new List<string>();
    var mappings = new Dictionary<char, IList<string>>()
    {
        ['2'] = new string[] { "a", "b", "c" },
        ['3'] = new string[] { "d", "e", "f" },
        ['4'] = new string[] { "g", "h", "i" },
        ['5'] = new string[] { "j", "k", "l" },
        ['6'] = new string[] { "m", "n", "o" },
        ['7'] = new string[] { "p", "q", "r", "s" },
        ['8'] = new string[] { "t", "u", "v" },
        ['9'] = new string[] { "w", "x", "y", "z" },
    };

    LetterCombinationsImpl(string.Empty);
    return results;

    void LetterCombinationsImpl(string buildup)
    {
        if (buildup.Length == digits.Length)
        {
            results.Add(buildup);
        }

        foreach (var digit in mappings[digits[buildup.Length]])
        {
            LetterCombinationsImpl(buildup + digit);
        }
    }
}