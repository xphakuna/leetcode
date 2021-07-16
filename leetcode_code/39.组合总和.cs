/*
 * @lc app=leetcode.cn id=39 lang=csharp
 *
 * [39] 组合总和
 */

// @lc code=start
public class Solution
{
    List<IList<int>> doCheck(int[] candidates, int idx, int target)
    {
        List<IList<int>> allRet = new List<IList<int>>();
        if (target == 0)
        {
            allRet.Add(new List<int>());
            return allRet;
        }
        //
        
        if (idx == candidates.Length-1)
        {
            if (target%candidates[idx] == 0)
            {
                List<int> one = new List<int>();
                for (int i=0; i<target/candidates[idx]; i++)
                {
                    one.Add(candidates[idx]);
                }
                allRet.Add(one);
            }
            return allRet;
        }
        //
        int cnt = target / candidates[idx];
        for (int i=0; i<=cnt; i++)
        {
            var allok = doCheck(candidates, idx + 1, target - i * candidates[idx]);
            
            foreach(var oneok in allok)
            {
                int sum = 0;
                foreach(var n in oneok)
                {
                    sum += n;
                }
                if (sum == target - i * candidates[idx])
                {
                    for (int j = 0; j < i; j++)
                    {
                        oneok.Add(candidates[idx]);
                    }
                    allRet.Add(oneok);
                }
                
            }
        }
        return allRet;
    }
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> allRet = new List<IList<int>>();
        Array.Sort(candidates, (a,b)=> { return b - a; });
        return doCheck(candidates, 0, target);
    }
}
// @lc code=end

