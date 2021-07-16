/*
 * @lc app=leetcode.cn id=64 lang=csharp
 *
 * [64] 最小路径和
 */

// @lc code=start
public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[,] dp = new int[m, n];

        for (int i_m=0; i_m<m; i_m++)
        {
            for (int i_n=0; i_n<n; i_n++)
            {
                if (i_m==0&&i_n==0)
                {
                    dp[0, 0] = grid[0][0];
                    continue;
                }
                int left = 9999;
                if (i_n>0)
                {
                    left = dp[i_m, i_n-1];
                }
                int up = 9999;
                if (i_m>0)
                {
                    up = dp[i_m-1, i_n];
                }
                dp[i_m, i_n] = Math.Min(left, up) + grid[i_m][i_n];
            }
        }
        return dp[m-1,n-1];
    }
}
// @lc code=end

