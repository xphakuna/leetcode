/*
 * @lc app=leetcode.cn id=63 lang=csharp
 *
 * [63] 不同路径 II
 */

// @lc code=start
public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        if (obstacleGrid[m-1][n-1] == 1)
        {
            return 0;
        }


        int[,] dp = new int[m,n];
        dp[0,0] = 1;
        for (int i_m=0; i_m<m; i_m++)
        {
            for (int i_n=0; i_n<n; i_n++)
            {
                if (i_m==0&&i_n == 0)
                {
                    continue;
                }
                if (obstacleGrid[i_m][i_n]>0)
                {
                    dp[i_m, i_n] = 0;
                }
                else
                {
                    int left = 0;
                    if (i_n > 0)
                    {
                        left = dp[i_m, i_n - 1];
                    }
                    int up = 0;
                    if (i_m > 0)
                    {
                        up = dp[i_m - 1, i_n];
                    }

                    dp[i_m, i_n] = left + up;
                }
                    
            }
        }
        //
        return dp[m - 1,n - 1];
    }
}
// @lc code=end

