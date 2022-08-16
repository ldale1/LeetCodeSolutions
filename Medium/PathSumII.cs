//Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.

//A root-to-leaf path is a path starting from the root and ending at any leaf node. A leaf is a node with no children.

//The number of nodes in the tree is in the range [0, 5000].
//-1000 <= Node.val <= 1000
//- 1000 <= targetSum <= 1000

using NUnit.Framework;


var tests = new[]
{
    (
        root: ListToTree(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null,null,null, 5, 1 }), 
        target: 22,
        output: new int[][] { new int[] { 5, 4, 11, 2 }, new int[] { 5, 8, 4, 5 } }
    ),

};
foreach (var test in tests)
{
    var answers = PathSum(test.root, test.target).ToList();
    Assert.That(answers, Is.EquivalentTo(test.output));
}

// Solution
IEnumerable<IList<int>> PathSum(TreeNode root, int targetSum)
{
    var queue = new Queue<(TreeNode Node, int Remaining, IList<int> Path)>(); ;
    queue.Enqueue((Node: root, Remaining: targetSum, Path: new List<int>()));

    var results = new List<IList<int>>();
    while (queue.Any())
    {
        var (node, remaining, path) = queue.Dequeue();
        if (remaining < 0)
        {
            continue;
        }

        var nextPath = new List<int>(path);
        nextPath.Add(node.val);

        if (remaining == node.val && node.left == null && node.right == null)
        {
            results.Add(nextPath);
            continue;
        }

        if (node.left != null)
        {
            queue.Enqueue((Node: node.left, Remaining: remaining - node.val, Path: nextPath));
        }

        if (node.right != null)
        {
            queue.Enqueue((Node: node.right, Remaining: remaining - node.val, Path: nextPath));
        }
    }

    return results;
}


TreeNode ListToTree(int?[] nodes)
{
    TreeNode Create(int index)
    {
        if (!(index < nodes.Length) || nodes[index] == null)
        {
            return null;
        }

        var node = new TreeNode((int)nodes[index]);
        node.left = Create(index * 2 + 1);
        node.right = Create(index * 2 + 2);
        return node;
    }

    return Create(0);
}

public class TreeNode {
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
 }