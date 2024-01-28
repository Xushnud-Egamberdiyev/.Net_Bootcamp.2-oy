public class Solution
{
    readonly Dictionary<char, int> map = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

    public int RomanToInt(string s)
    {
        int result = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            if (i == s.Length - 1)
            {
                result += map[s[i]];
                break;
            }
            if (map[s[i]] >= map[s[i + 1]])
                result += map[s[i]];
            else
            {
                result += map[s[i + 1]] - map[s[i]];
                i++;
            }
        }
        return result;
    }
}