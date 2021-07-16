using System;
using System.Collections.Generic;


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

        public static void Test_FindBiggerThan()
        {
            int ret = 0;
            ret = FindBiggerThan(new List<int>(new int[]{ 1, 2, 4, 4, 7 }), 0, 3, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 2);
            ret = FindBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 0, 4, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 4);
            ret = FindBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 0, 999, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == -1);

            ret = FindBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 1, 1, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 1);
        }

        public static int FindEqualBiggerThan<T>(IList<T> newp, int idx_start, int n, System.Func<T, int> calc)
        {
            int ret = FindBiggerThan(newp, idx_start, n - 1, calc);
            return ret;
        }

        public static void Test_FindEqualBiggerThan()
        {
            int ret = 0;
            ret = FindEqualBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 0, 3, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 2);
            ret = FindEqualBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 0, 4, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 2);
            ret = FindEqualBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 0, 999, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == -1);

            ret = FindEqualBiggerThan(new List<int>(new int[] { 1, 2, 4, 4, 7 }), 1, 1, (a) => { return a; });
            System.Diagnostics.Debug.Assert(ret == 1);
        }
    }
}
