/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution
{
    bool isDup(Dictionary<int, Dictionary<int, bool>> dict_x1_x2, int a, int b)
    {
        if (dict_x1_x2.ContainsKey(a) && dict_x1_x2[a].ContainsKey(b))
        {
            return true;
        }
        return false;
    }
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        //
        List<IList<int>> ret = new List<IList<int>>();
        if (nums.Length < 3)
            return ret;

        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach(var n in nums)
        {
            if (dict.ContainsKey(n))
            {
                dict[n] = dict[n] + 1;
            }
            else
            {
                dict[n] = 1;
            }
        }

        Dictionary<int, Dictionary<int, bool>> dict_x1_x2 = new Dictionary<int, Dictionary<int, bool>>();

        for (int i=0; i<= nums.Length-3; i++)
        {
            if (nums[i]>0)
            {
                break;
            }
            for (int j=i+1; j<= nums.Length - 2; j++)
            {

                //
                int x1 = nums[i];
                int x2 = nums[j];
                int x3 = 0 - x1 - x2;
                if (x3 < x2)
                {
                    break;
                }
               

                if (isDup(dict_x1_x2, x1, x2))
                    continue;


                bool isok = false;
                if (x3==x1 && x3==x2)
                {
                    if (dict[x3]>=3)
                    {
                        isok = true;
                    }
                }
                else if (x3==x2)
                {
                    if (dict[x3] >= 2)
                    {
                        isok = true;
                    }
                }
                else
                {
                    if (dict.ContainsKey(x3))
                    {
                        isok = true;
                        
                    }
                }
                if (isok)
                {
                    List<int> one = new List<int>(3);
                    one.Add(x1); one.Add(x2); one.Add(x3);
                    ret.Add(one);

                    if (!dict_x1_x2.ContainsKey(x1))
                    {
                        dict_x1_x2[x1] = new Dictionary<int, bool>();
                    }
                    dict_x1_x2[x1][x2] = true;
                }
            }
        }

        return ret;
    }
}
// @lc code=end

