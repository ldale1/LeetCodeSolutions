//You are given two non-empty linked lists representing two non-negative integers. 
//The digits are stored in reverse order, and each of their nodes contains a single digit. \
//Add the two numbers and return the sum as a linked list.

//The number of nodes in each linked list is in the range [1, 100].
//0 <= Node.val <= 9
//It is guaranteed that the list represents a number that does not have leading zeros.

using NUnit.Framework;

var tests = new[]
{
    (
        First:  GetListNode(new [] {2, 4, 3}),
        Second: GetListNode(new [] {5, 6, 4}),
        Output: GetListNode(new [] {7, 0, 8})
    ),
    (
        First:  GetListNode(new [] {2, 4, 3, 1}),
        Second: GetListNode(new [] {5, 6, 4}),
        Output: GetListNode(new [] {7, 0, 8, 1})
    ),
    (
        First:  GetListNode(new [] {9}),
        Second: GetListNode(new [] {2}),
        Output: GetListNode(new [] {1, 1})
    ),
};


foreach (var test in tests)
{
    Assert.That(AddTwoNumbers(test.First, test.Second), Is.EqualTo(test.Output).Using<ListNode>(AreEqual));
}

// Solution
ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    var root = new ListNode();
    var current = root;

    var c1 = l1;
    var c2 = l2;

    int sum = 0;
    while (c1 != null || c2 != null)
    {
        // Take off the first digit
        sum /= 10;

        // Sum the values
        sum += c1?.val ?? 0;
        sum += c2?.val ?? 0;

        // Move nodes along
        c1 = c1?.next;
        c2 = c2?.next;

        var nextNode = new ListNode(val: sum % 10);
        current.next = nextNode;
        current = current.next;
    }

    // Potential carry
    if (sum > 9)
    {
        var nextNode = new ListNode(val: sum / 10);
        current.next = nextNode;
    }

    return root.next ?? new ListNode();
}

// Compare list nodes
bool AreEqual(ListNode node1, ListNode node2)
{
    var c1 = node1;
    var c2 = node2;

    while (c1 != null && c2 != null)
    {
        if (c1.val != c2.val)
        {
            return false;
        }

        c1 = c1.next;
        c2 = c2.next;
    }

    return c1 == null && c2 == null;
}

// nums always has atleast 1 element
ListNode GetListNode(int[] nums)
{
    var root = new ListNode();
    var current = root;
    foreach (var num in nums)
    {
        var next = new ListNode(val: num);
        current.next = next;
        current = next;
    }
    return root.next ?? new ListNode();
}

// lc definition
public class ListNode
{
    public int val { get; set; }
    public ListNode? next { get; set; }

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

