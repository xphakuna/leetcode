/*
 * @lc app=leetcode.cn id=62 lang=csharp
 *
 * [62] 不同路径
 */

// @lc code=start
public class Solution
{
    Dictionary<int, int> m_cache = new Dictionary<int, int>();
    int doUniquePaths(int m, int n, int i, int j)
    {
        if (i==m-1 || j==n-1)
        {
            return 1;
        }
        int key = i * 1000 + j;
        if (m_cache.ContainsKey(key))
        {
            return m_cache[key];
        }
        int right = doUniquePaths(m, n, i + 1, j);
        int down = doUniquePaths(m, n, i, j+1);
        m_cache[key] = right + down;
        return right + down;
    }

    public int UniquePaths(int m, int n)
    {
        
        return doUniquePaths(m, n, 0, 0);
    }
}
// @lc code=end

