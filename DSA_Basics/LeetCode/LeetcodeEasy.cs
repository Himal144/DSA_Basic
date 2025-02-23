using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Basics.LeetCode
{
    public class LeetcodeEasy
    {
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            map['I'] = 1;
            map['V'] = 5;
            map['X'] = 10;
            map['L'] = 50;
            map['C'] = 100;
            map['D'] = 500;
            map['M'] = 1000;


            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && map[s[i]] < map[s[i + 1]])
                {
                    sum -= map[s[i]];
                }
                else
                {
                    sum += map[s[i]];
                }
            }
            return sum;
        }


        public static string LongestPrefixString(string[] strings)
        {

            string longestPrefix = strings[0];

            for (int i = 1; i < strings.Length; i++)
            {
                int subLength = 0;
                for (int j = 0; j < strings[i].Length; j++)
                {
                    if (j < longestPrefix.Length && longestPrefix[j] == strings[i][j])
                    {
                        subLength++;
                    }
                    else
                    {
                        break;
                    }
                }
                longestPrefix = longestPrefix.Substring(0, subLength);

            }
            return longestPrefix;
        }
    }
}
