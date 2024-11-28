namespace HomeWork9;

internal class BinaryTree
{
    private List<TreeNode> Nodes { get; } = new();
    private TreeNode? RootNode { get; set; }

    public void Add(string textValue, int value)
    {
        var node = new TreeNode { Value = value, TextValue = textValue };
        Nodes.Add(node);
        if (RootNode == null) RootNode = node;
        AddNode(RootNode, node);
    }

    public void AddNode(TreeNode root, TreeNode node)
    {
        if (root == node) return;

        if (node.Value < root.Value)
        {
            if (root.Left == null)
                root.Left = node;
            else
                AddNode(root.Left, node);
        }
        else
        {
            if (root.Right == null)
                root.Right = node;
            else
                AddNode(root.Right, node);
        }
    }

    public static TreeNode? FindNode(BinaryTree tree, int value)
    {
        if (tree.RootNode == null) return null;
        return tree.RootNode.Value == value ? tree.RootNode : FindNodeByValue(tree.RootNode, value);
    }
    public static TreeNode? FindNodeByValue(TreeNode root, int value)
    {
        if (root.Value == value) return root;
        return root.Value > value ? FindNodeByValue(root.Left, value)! : FindNodeByValue(root.Right, value)!;
    }

    public static void TraverseTree(BinaryTree tree)
    {
        if (tree.RootNode != null) Traverse(tree.RootNode);
    }

    private static void Traverse(TreeNode originNode)
    {
        if (originNode.Left != null) Traverse(originNode.Left);
        Console.WriteLine("Employee: {0}    salary:{1}", originNode.TextValue, originNode.Value);
        if (originNode.Right != null) Traverse(originNode.Right);
    }

    internal class TreeNode
    {
        public string TextValue { get; set; }
        public int Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
    }
}