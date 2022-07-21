//The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

//P A   H   N
//A P L S I I G
//Y   I   R
//And then read line by line: "PAHNAPLSIIGYIR"

//Write the code that will take a string and make this conversion given a number of rows:

using NUnit.Framework;
using System.Text;

var tests = new[]
{
    (input: "PAYPALISHIRING", numRows: 3, output: "PAHNAPLSIIGYIR"),
    (input: "PAYPALISHIRING", numRows: 4, output: "PINALSIGYAHRPI"),
    (input: "A", numRows: 1, output: "A"),
};

foreach (var test in tests)
{
    Assert.That(Convert(test.input, test.numRows), Is.EqualTo(test.output));
}

// Solution
string Convert(string s, int numRows)
{
    if (numRows == 1)
    {
        return s;
    }

    var stringBuilders = new StringBuilder[numRows];
    for (int i = 0; i < numRows; i++)
    {
        stringBuilders[i] = new StringBuilder();
    }

    var row = 0;
    var increment = 1;
    for (int i = 0; i < s.Length; i++)
    {
        stringBuilders[row].Append(s[i]);

        row += increment;
        if ((row == 0) || (row == numRows - 1))
        {
            increment *= -1;
        }
    }

    return stringBuilders
        .Aggregate(new StringBuilder(), (a, b) => a.Append(b))
        .ToString();
}