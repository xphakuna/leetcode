/*
 * @lc app=leetcode.cn id=56 lang=csharp
 *
 * [56] 合并区间
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

    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1)
            return intervals;
        //
        List<int[]> newp = new List<int[]>();
        for (int i=0; i<intervals.Length; i++)
        {
            newp.Add(intervals[i]);
        }
        newp.Sort((a, b) =>
        {
            return a[0] - b[0];
        });

        List<int[]> ret = new List<int[]>();
        for (int i=0; i<newp.Count; )
        {
            int[] range = newp[i];
            int bigger = -1;
            while (true)
            {
                bigger = FindBiggerThan(newp, i + 1, range[1], (a) => { return a[0]; });
                if (bigger == -1)
                {
                    for (int j=i+1;j<newp.Count;j++)
                    {
                        range[1] = Math.Max(range[1], newp[j][1]);
                    }
                    ret.Add(range);
                    return ret.ToArray();
                }
                // need break
                else if (bigger == i+1)
                {
                    ret.Add(range); // to next iteratation
                    i = bigger;
                    break;
                }
                else
                {
                    for (int j=i+1;j<bigger; j++)
                    {
                        range[1] = Math.Max(range[1], newp[j][1]);
                    }
                    i = bigger-1;
                }
            }
        }

        return ret.ToArray();
    }
}
// @lc code=end

