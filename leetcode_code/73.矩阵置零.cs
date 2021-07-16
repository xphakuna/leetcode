/*
 * @lc app=leetcode.cn id=73 lang=csharp
 *
 * [73] 矩阵置零
 */

// @lc code=start
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int[] zero_columns = new int[matrix[0].Length];
        for (int ic=0;ic<matrix.Length; ic++)
        {
            bool has_zero = false;
            for (int ir=0; ir<matrix[0].Length; ir++)
            {
                if (matrix[ic][ir] == 0)
                {
                    has_zero = true;
                    zero_columns[ir] = 1;
                }
            }
            if (has_zero)
            {
                for (int ir = 0; ir < matrix[0].Length; ir++)
                {
                    matrix[ic][ir] = 0;
                }
            }
        }
        //
        for (int ir=0;ir< zero_columns.Length; ir++)
        {
            if (zero_columns[ir]>0)
            {
                for (int ic = 0; ic < matrix.Length; ic++)
                {
                    matrix[ic][ir] = 0;
                }
            }
        }
    }
}
// @lc code=end

