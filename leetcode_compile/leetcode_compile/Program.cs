using System;
using System.Collections.Generic;


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
            Utils.Test_FindBiggerThan();
            Utils.Test_FindEqualBiggerThan();

            Solution s = new Solution();
            var ret = s.SearchMatrix(parseParam("1,3,5,7],[10,11,16,20],[23,30,34,60"), 13);
            Console.WriteLine("Hello World!");
        }
    }
}
