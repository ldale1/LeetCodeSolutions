//Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

//The number of nodes in the tree is in the range [0, 2000].
//-1000 <= Node.val <= 1000

//Input: root = [3,9,20,null,null,15,7]
//Output: [[3],[9,20],[15,7]]

using NUnit.Framework;


//Binary Tree Level Order Traversal
var tests = new[]
{
    (
        root: GetTree(new int?[] {3, 9, 20, null, null, 15, 7 }),
        levels: new []
        {
            new [] {3},
            new [] {9,20},
            new [] {15,7},
        }
    ),
};

foreach (var test in tests)
{
    Assert.That(LevelOrder(test.root), Is.EqualTo(test.levels));
}

// Solution
IList<IList<int>> LevelOrder(TreeNode root)
{
    var rows = new List<IList<int>>();
    if (root == null)
    {
        return rows;
    }

    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);

    do
    {
        var row = new List<int>();
        var iterations = queue.Count;
        for (int i = 0; i < iterations; i++)
        {
            var item = queue.Dequeue();
            row.Add(item.val);

            if (item.left != null)
            {
                queue.Enqueue(item.left);
            }

            if (item.right != null)
            {
                queue.Enqueue(item.right);
            }
        }

        rows.Add(row);
    } while (queue.Any());

    return rows;
}


TreeNode GetTree(int?[] nums)
{
    TreeNode? FromIndex(int index)
    {
        if (index > nums.Length)
        {
            return null;
        }

        var num = nums[index];
        if (!num.HasValue)
        {
            return null;
        }

        return new TreeNode(num.Value, FromIndex(index * 2 + 1), FromIndex(index * 2 + 2));
    };

    return FromIndex(0) ?? new TreeNode();
}

 // Definition for a binary tree node.
 public class TreeNode {
     public int val;
     public TreeNode? left;
     public TreeNode? right;
     
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }
 
