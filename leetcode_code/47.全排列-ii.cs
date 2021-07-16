/*
 * @lc app=leetcode.cn id=47 lang=csharp
 *
 * [47] 全排列 II
 */

// @lc code=start
public class Solution
{
    void swap(List<int> one, int i, int j)
    {
        int t = one[i];
        one[i] = one[j];
        one[j] = t;
    }

    void reverseAfter(List<int> one, int idx)
    {
        int first = idx;
        int last = one.Count - 1;
        int middle = (first + last) / 2;
        for (int i=first; i<=middle; i++)
        {
            swap(one, i, (first + last - i));
        }
    }

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        List<IList<int>> ret = new List<IList<int>>();
        Array.Sort(nums);
        List<int> tmp = new List<int>();
        tmp.AddRange(nums);
        ret.Add(tmp);
        //
        while (true)
        {
            int idx = -1;
            IList<int> last_list = ret[ret.Count - 1];
            for (int i= last_list.Count-1; i>=1; i--)
            {
                if (last_list[i-1]< last_list[i])
                {
                    idx = i - 1;
                    break;
                }
            }
            if (idx == -1)
                break;
            //
            List<int> cur_list = new List<int>();
            cur_list.AddRange(last_list);

            int idx_bigger = -1;
            for (int i = cur_list.Count - 1; i > idx; i--)
            {
                if (cur_list[i] > cur_list[idx])
                {
                    idx_bigger = i;
                    break;
                }
            }

            swap(cur_list, idx, idx_bigger);
            reverseAfter(cur_list, idx + 1);
            ret.Add(cur_list);
        }

        return ret;
    }
}
// @lc code=end

