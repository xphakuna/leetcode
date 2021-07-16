using System;
using System.Collections.Generic;


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

namespace leetcode_compile
{
    class Program
    {
        static int[][] parseParam(string str)
        {
            var lines = str.Split("],[");
            List<int[]> ret = new List<int[]>();
            for (int i=0; i<lines.Length; i++)
            {
                var tline = lines[i].Split(",".ToCharArray());
                int[] oneline = new int[tline.Length];
                for (int j=0; j<tline.Length; j++)
                {
                    int tmp = 0;
                    if (!int.TryParse(tline[j], out tmp))
                    {
                        System.Diagnostics.Debug.WriteLine("bad parse " + tline[j]);
                    }
                    oneline[j] = tmp;
                }
                ret.Add(oneline);
            }
            return ret.ToArray();
        }
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var ret = s.MinPathSum(parseParam("1,3,1],[1,5,1],[4,2,1"));
            Console.WriteLine("Hello World!");
        }
    }
}
