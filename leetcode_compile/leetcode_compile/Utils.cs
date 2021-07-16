using System;

namespace leetcode_compile
{
    class Utils
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
    }
}
