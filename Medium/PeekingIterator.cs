//Design an iterator that supports the peek operation on an existing iterator in addition to the hasNext and the next operations.

//Implement the PeekingIterator class:
//PeekingIterator(Iterator<int> nums) Initializes the object with the given integer iterator iterator.
//int next() Returns the next element in the array and moves the pointer to the next element.
//boolean hasNext() Returns true if there are still elements in the array.
//int peek() Returns the next element in the array without moving the pointer.
//using NUnit.Framework;

using NUnit.Framework;

IEnumerable<object> RunIterator(PeekingIterator p, params Func<PeekingIterator, object>[] methods)
{
    foreach (var method in methods)
    {
        yield return method(p);
    }
}

var tests = new (IEnumerator<int> Input, Func<PeekingIterator, object[]> Sequence, object[] Expected)[]
{
    (
        Input: new List<int>{ 1, 2, 3 }.GetEnumerator(),
        Sequence: p => RunIterator(p, p => p.Next(), p => p.Peek(), p => p.Next(), p => p.Next(), p => p.HasNext()).ToArray(),
        Expected:  new object[] { 1, 2, 2, 3, false }
    ),
};

foreach (var test in tests)
{
    // iterators refers to the first element of the array.
    test.Input.MoveNext();

    var actual = test.Sequence(new PeekingIterator(test.Input));
    Assert.That(actual, Is.EquivalentTo(test.Expected));
}

class PeekingIterator
{
    private Queue<int> m_queue = new Queue<int>();

    // iterators refers to the first element of the array.
    public PeekingIterator(IEnumerator<int> iterator)
    {
        do
        {
            m_queue.Enqueue(iterator.Current);
        } while (iterator.MoveNext());
    }

    // Returns the next element in the iteration without advancing the iterator.
    public int Peek()
        => m_queue.Peek();

    // Returns the next element in the iteration and advances the iterator.
    public int Next()
        => m_queue.Dequeue();

    // Returns false if the iterator is refering to the end of the array of true otherwise.
    public bool HasNext()
        => m_queue.Any();
}