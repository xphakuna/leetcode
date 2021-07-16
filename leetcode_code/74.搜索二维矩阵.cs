/*
 * @lc app=leetcode.cn id=74 lang=csharp
 *
 * [74] 搜索二维矩阵
 */

// @lc code=start
public class Solution
{
    public static int FindBiggerThan<T>(IList<T> newp, int idx_start, int n, System.Func<T, int> calc)
    {
        int b = idx_start;
        int e = newp.Count - 1;
        while (b < e)
        {
            int m = (b + e) / 2;
            int v = calc(newp[m]);
            if (v < n) b = m + 1;
            else if (v > n) e = m - 1;
            else break;
        }
        for (int i = (b + e) / 2; i < newp.Count; i++)
        {
            if (calc(newp[i]) > n)
                return i;
        }
        return -1;
    }

    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        List<int> front_end = new List<int>(m*2);
        for (int i=0; i<matrix.Length; i++)
        {
            front_end.Add(matrix[i][0]);
            front_end.Add(matrix[i][n-1]);
        }

        int idx = FindBiggerThan(front_end, 0, target-1, (a) => { return a; });
        if (idx == -1)
            return false;
        if (front_end[idx] == target)
        {
            return true;
        }
        bool isBegin = idx % 2 == 0;
        if (isBegin)
            return false;
        //
        front_end.Clear();
        front_end.AddRange(matrix[idx / 2]);
        idx = FindBiggerThan(front_end, 0, target-1, (a) => { return a; });
        if (idx == -1)
            return false;
        return front_end[idx] == target;
    }
}
// @lc code=end

