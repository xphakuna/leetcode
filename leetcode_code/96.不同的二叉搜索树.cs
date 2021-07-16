/*
 * @lc app=leetcode.cn id=96 lang=csharp
 *
 * [96] 不同的二叉搜索树
 */

// @lc code=start
public class Solution
{
    int GenTree(int n, int MIN, int MAX)
    {
        int savedKey = get_savedKey(n, MIN, MAX);
        if (saved.ContainsKey(savedKey))
        {
            return saved[savedKey];
        }

        int allLeft = 0;
        int allRight = 0;
        for (int i=MIN; i<n; i++)
        {
            allLeft += GenTree(i, MIN, n-1);
        }
        for (int i = n + 1; i <= MAX; i++)
        {
            allRight += GenTree(i, n + 1, MAX);
        }


        int ret = 0;
        if (allLeft== 0 && allRight == 0)
        {
            ret = 1;
        }
        else if (allLeft ==0)
        {
            ret = allRight;
        }
        else if (allRight == 0)
        {
            ret = allLeft;
        }
        else
        {
            ret = allLeft * allRight;
        }

        saved[savedKey] = ret;

        return ret;
    }

    int get_savedKey(int n, int MIN, int MAX)
    {
        return (n-MIN) * 100 + (MAX-n);
    }

    Dictionary<int, int> saved = new Dictionary<int, int>();

    public int NumTrees(int n)
    {
        int sum = 0;
        for (int i=1; i<=n/2; i++)
        {
            sum += 2*GenTree(i, 1, n);
        }
        if (n%2==1)
        {
            sum += GenTree(n/2+1, 1, n);
        }
        return sum;
    }
}
// @lc code=end

