/*
 * @lc app=leetcode.cn id=95 lang=csharp
 *
 * [95] 不同的二叉搜索树 II
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    List<TreeNode> GenTree(int n, int MIN, int MAX)
    {
        List<TreeNode> allLeft = new List<TreeNode>();
        List<TreeNode> allRight = new List<TreeNode>();
        for (int i=MIN; i<n; i++)
        {
            allLeft.AddRange(GenTree(i, MIN, n-1));
        }
        for (int i = n+1; i <= MAX; i++)
        {
            allRight.AddRange(GenTree(i, n+1, MAX));
        }
        List<TreeNode> ret = new List<TreeNode>();
        if (allLeft.Count == 0 && allRight.Count == 0)
        {
            TreeNode tn = new TreeNode(n, null, null);
            ret.Add(tn);
        }
        else if (allLeft.Count==0)
        {
            for (int i=0; i<allRight.Count; i++)
            {
                TreeNode tn = new TreeNode(n, null, allRight[i]);
                ret.Add(tn);
            }
        }
        else if (allRight.Count == 0)
        {
            for (int i = 0; i < allLeft.Count; i++)
            {
                TreeNode tn = new TreeNode(n, allLeft[i], null);
                ret.Add(tn);
            }
        }
        else
        {
            for (int i = 0; i < allLeft.Count; i++)
            {
                for (int j=0; j<allRight.Count; j++)
                {
                    TreeNode tn = new TreeNode(n, allLeft[i], allRight[j]);
                    ret.Add(tn);
                }
            }
        }
        return ret;
    }

    void dumpTreeLine(TreeNode tn)
    {
        dumpTree(tn);
        Console.Write("\n");
    }

    void dumpTree(TreeNode tn)
    {
        if (tn == null)
        {
            Console.Write("null,");
            return;
        }
        Console.Write(tn.val+",");
        if (tn.left!=null)
        {
            dumpTree(tn.left);
        }
        else
        {
            Console.Write("null,");
        }
        if (tn.right != null)
        {
            dumpTree(tn.right);
        }
        else
        {
            Console.Write("null,");
        }
    }

    public IList<TreeNode> GenerateTrees(int n)
    {
        List<TreeNode> allTreeNode = new List<TreeNode>();
        for (int i=1; i<=n; i++)
        {
            var tmp = GenTree(i, 1, n);
            allTreeNode.AddRange(tmp);

            Console.Write(i+"::::::\n");
            foreach (var one in tmp)
            {
                dumpTreeLine(one);
            }
        }
        return allTreeNode;
    }
}

// @lc code=end

