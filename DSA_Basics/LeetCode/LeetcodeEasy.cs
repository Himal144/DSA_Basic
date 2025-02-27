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

        public static int[] LongestConsecutiveSequence(int[] numbers)
        {
            HashSet<int> numSet = new HashSet<int>(numbers);
            int sequenceLength = 0;
            List<int> longestSequence = new List<int>();
            foreach (int num in numSet)
            {
               
                List<int> currentSequence = new List<int>();
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    while (numSet.Contains(currentNum))
                    {
                        currentSequence.Add(currentNum);
                        currentNum++;
                    }
                    if(currentSequence.Count > sequenceLength)
                    {
                        sequenceLength = currentSequence.Count;
                        longestSequence = new List<int> (currentSequence);
                    }
                }
            }
            return longestSequence.ToArray();
        }

        public static bool CheckValidParanthesis(string paranthesis)
        {
            Stack<char> stack = new Stack<char>();

            Dictionary<char, char> matchingPairs = new Dictionary<char, char>
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

            foreach (char ch in paranthesis)
            {
                if (matchingPairs.ContainsValue(ch)) // Opening bracket
                {
                    stack.Push(ch);
                }
                else if (matchingPairs.ContainsKey(ch)) // Closing bracket
                {
                    if (stack.Count == 0 || stack.Pop() != matchingPairs[ch])
                    {
                        return false; // Mismatched or extra closing bracket
                    }
                }
            }

            return stack.Count == 0; // Stack should be empty if valid
        }

        //Remove specific element from the array changing the original array
        public int RemoveDuplicate(int[] nums, int num)
        {
            int index = 0; // Keeps track of non-matching elements

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != num)
                {
                    nums[index] = nums[i]; // Overwrite unwanted elements
                    index++;
                }
            }

            return index; // New length of the array after removal
        }

        public int StrStr(string heystack,string needle)
        {
            int heyStackLength= heystack.Length;
            int needleLength = needle.Length;
            for (int i =0; i <= heyStackLength - needleLength; i++)
            {
                int j = 0;
                while (j<needleLength && heystack[i + j] == needle[j])
                {
                    j++;
                }
                if(j == needleLength)
                {
                    return i;
                }
              
            }
            return -1;
        }
    }
}
