//You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

//Merge all the linked-lists into one sorted linked-list and return it.

//k == lists.length
//0 <= k <= 104
//0 <= lists[i].length <= 500
//- 104 <= lists[i][j] <= 104
//lists[i] is sorted in ascending order.
//The sum of lists[i].length will not exceed 104.

using NUnit.Framework;

var tests = new[]
{
    (
        input: new ListNode[] 
        {
            CreateListNode(new int[] {1,4,5}),
            CreateListNode(new int[] {1,3,4}),
            CreateListNode(new int[] {2,6})
        }, 
        output: CreateListNode(new int[] {1,1,2,3,4,4,5,6})
    )
};
foreach (var test in tests)
{
    Assert.That(MergeKLists(test.input), Is.EqualTo(test.output).Using<ListNode>(AreEqual));
}

// Solution
ListNode MergeKLists(ListNode[] lists)
{
    var root = new ListNode();
    var current = root;
    var queue = new PriorityQueue<ListNode, int>();

    foreach (var list in lists)
    {
        if (list != null)
        {
            queue.Enqueue(list, list.val);
        }        
    }

    while (queue.TryDequeue(out var next, out int priority))
    {
        current.next = next;
        current = next;

        if (next.next != null)
        {
            queue.Enqueue(next.next, next.next.val);
        }
    }

    return root.next;
}

ListNode CreateListNode(int[] elements)
{
    if (!elements.Any())
    {
        return null;
    }

    var root = new ListNode();
    var current = root;
    for (int i = 0; i < elements.Length; i++)
    {
        var temp = new ListNode(elements[i]);
        current.next = temp;
        current = temp;
    }

     return root.next;
}

bool AreEqual(ListNode a, ListNode b)
{
    if (a == null && b == null)
    {
        return true;
    }

    if (a == null || b == null)
    { 
        return false;
    }

    return a.val == b.val && AreEqual(a.next, b.next);
}

public class ListNode
{
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
 }

