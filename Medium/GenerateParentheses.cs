//Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses. 

//Constraints:

//1 <= n <= 8


using NUnit.Framework;

var tests = new[]
{
    (input: 3, output: new string[] { "((()))","(()())","(())()","()(())","()()()" }),
    (input: 1, output: new string[] { "()" }),

};
foreach (var test in tests)
{
    var answers = GenerateParenthesis(test.input);
    Assert.That(answers, Is.EquivalentTo(test.output));
}

// Solution
IList<string> GenerateParenthesis(int n)
{
    var results = new List<string>();

    Add("(", n - 1, n);

    return results;


    void Add(string buildup, int open, int closed)
    {
        if (open == 0 && closed == 0)
        {
            results.Add(buildup);
            return;
        }

        if (open != 0)
        {
            Add(buildup + "(", open - 1, closed);
        }

        if (open < closed)
        {
            Add(buildup + ")", open, closed - 1);
        }
    }
}