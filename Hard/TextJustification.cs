//Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

//You should pack your words in a greedy approach; that is, pack as many words as you can in each line.Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

//Extra spaces between words should be distributed as evenly as possible.If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

//For the last line of text, it should be left-justified, and no extra space is inserted between words.

//Note:

//A word is defined as a character sequence consisting of non-space characters only.
//Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
//The input array words contains at least one word.

using NUnit.Framework;
using System.Text;

var tests = new[]
{
    (
        input: new [] { "This", "is", "an", "example", "of", "text", "justification." },
        maxWidth: 16,
        output: new [] { "This    is    an", "example  of text", "justification.  " }
    ),
    (
        input: new [] { "What","must","be","acknowledgment","shall","be" },
        maxWidth: 16,
        output: new [] { "What   must   be", "acknowledgment  ", "shall be        " }
    ),
    (
        input: new [] {"Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do" },
        maxWidth: 20,
        output: new [] { "Science  is  what we", "understand      well", "enough to explain to", "a  computer.  Art is", "everything  else  we", "do                  " }
    ),
};

foreach (var test in tests)
{
    Assert.That(FullJustify(test.input, test.maxWidth), Is.EqualTo(test.output));
}

// Solution
IList<string> FullJustify(string[] words, int maxWidth)
{
    var rows = new List<string>();
    int start = 0;
    var remaining = maxWidth;
    for (int end = 0; end < words.Length; end++)
    {
        var word = words[end];
        if (word.Length > remaining)
        {
            var stringified = end - start != 1
                ? FormatRow(start, end - 1)
                : FormatFinalRow(start, end - 1);
            rows.Add(stringified);

            start = end;
            remaining = maxWidth;
        }

        remaining -= word.Length + 1;
    }

    rows.Add(FormatFinalRow(start, words.Length - 1));

    return rows;

    string FormatRow(int start, int end)
    {
        var wordSum = Enumerable.Range(start, end - start + 1).Sum(i => words[i].Length);
        var spaces = maxWidth - wordSum;
        var builder = new StringBuilder();
        for (int i = start; i < end; i++)
        {
            builder.Append(words[i]);

            var spacing = (int)Math.Ceiling(spaces / (end - (double)i));
            builder.Append(new String(' ', spacing));
            spaces -= spacing;
        }

        builder.Append(words[end]);
        return builder.ToString();
    }

    string FormatFinalRow(int start, int end)
    {
        var builder = new StringBuilder();
        for (int i = start; i < end; i++)
        {
            builder.Append(words[i]);
            builder.Append(" ");
        }

        builder.Append(words[end]);
        builder.Append(new String(' ', maxWidth - builder.Length));
        return builder.ToString();
    }
}