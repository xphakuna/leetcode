/*
 * @lc app=leetcode.cn id=50 lang=csharp
 *
 * [50] Pow(x, n)
 */

// @lc code=start
public class Solution
{
    double dopow(double x, int n)
    {
        if (n==0)
        {
            return 1;
        }
        if (n==1)
        {
            return x;
        }
        int n1 = n / 2;
        int n2 = n - n1;
        var y = dopow(x, n1);
        if (n1 == n2)
        {
            return y * y;
        }
        else
        {
            return y * y * x;
        }
    }
    public double MyPow(double x, int n)
    {
        if (n<0)
        {
            return 1 / dopow(x, -n);
        }
        else
        {
            return dopow(x, n);
        }
    }
}
// @lc code=end

