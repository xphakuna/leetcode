/*
 * @lc app=leetcode.cn id=40 lang=csharp
 *
 * [40] 组合总和 II
 */

// @lc code=start
public class Solution
{
    List<IList<int>> doCheck(List<Tuple<int, int>> candidates, int idx, int target)
    {
        List<IList<int>> allRet = new List<IList<int>>();
        if (target == 0)
        {
            allRet.Add(new List<int>());
            return allRet;
        }
        //

        if (idx == candidates.Count - 1)
        {
            int need = target / candidates[idx].Item1;
            if (target % candidates[idx].Item1 == 0 && need<= candidates[idx].Item2)
            {
                List<int> one = new List<int>();
                for (int i = 0; i < need; i++)
                {
                    one.Add(candidates[idx].Item1);
                }
                allRet.Add(one);
            }
            return allRet;
        }
        //
        int cnt = target / candidates[idx].Item1;
        cnt = Math.Min(cnt, candidates[idx].Item2);
        for (int i = 0; i <= cnt; i++)
        {
            var allok = doCheck(candidates, idx + 1, target - i * candidates[idx].Item1);

            foreach (var oneok in allok)
            {
                int sum = 0;
                foreach (var n in oneok)
                {
                    sum += n;
                }
                if (sum == target - i * candidates[idx].Item1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        oneok.Add(candidates[idx].Item1);
                    }
                    allRet.Add(oneok);
                }

            }
        }
        return allRet;
    }
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        List<IList<int>> allRet = new List<IList<int>>();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i=0; i<candidates.Length; i++)
        {
            if (!dict.ContainsKey(candidates[i]))
            {
                dict[candidates[i]] = 0;
            }

            dict[candidates[i]]++;
        }
        List<Tuple<int, int>> data = new List<Tuple<int, int>>();
        foreach(var kv in dict)
        {
            var t = new Tuple<int, int>(kv.Key, kv.Value);
            data.Add(t);
        }
        data.Sort((a, b) => { return b.Item1-a.Item1; });
        return doCheck(data, 0, target);
    }
}
// @lc code=end

