using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

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

        //Function used to search the position of the particular element in the sorted array and give position if find and insert position if not find
        public int SearchInsertPosition(int[] nums,int target)
        {
            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        //Function used to find the length of the last word consisting non space.

        public int LengthOfLastWord(string sentence)
        {
            int i = sentence.Length-1;
            int length = 0;
            while (i >= 0)
            {
                if (sentence[i] != ' ')
                {
                    length++;
                }
                else if (length > 0 && sentence[i] == ' ')
                {
                    break;
                }
                i--;
            }
            return length;
        }

        //Function used to sum the current element present in the array and add one to it and represent it back to array.

        public int[] AddOne(int[] nums)
        {

           int length = nums.Length;

            for(int i = length-1; i >= 0; i--)
            {
                if (nums[i] < 9)
                {
                    nums[i]++;
                    return nums;
                }
                nums[i] = 0;
            }
            int[] result = new int[length+1];
            result[0] = 1;
            return result;
        }


        //Function for adding binary two numbers given in string


        public string AddBinary(string num1, string num2)
        {
            int length1 = num1.Length - 1;
            int length2 = num2.Length - 1;

            List<int> result = new List<int>();

            int currentCarry = 0;

            while (length1 >= 0 || length2 >= 0 || currentCarry > 0)
            {
                int i = length1 >= 0 ? num1[length1] - '0' : 0;
                int j = length2 >= 0 ? num2[length2] - '0' : 0;
                int sum = i + j + currentCarry;

                result.Add(sum % 2);
                currentCarry = sum / 2;
                length1--;
                length2--;
            }

            char[] output = new char[result.Count];
            int index = 0;

            for (int i = result.Count - 1; i >= 0; i--)
            {
                output[index] = (char)(result[i] + '0');
                index++;
            }
            return new string(output);

        }

        //Function used to calculate the unique way to  upstaris 1 and 2 step

        public int ClimbStairs(int n)
        {
            int first = 1;
            int second = 2;
            if (n == 1) return first;

            for (int i = 3; i <= n; i++)
            {
                int temp = first + second;
                first = second;
                second = temp;
            }
            return second;
        }

        //Function used to calculate the square root without using the builtin function.

        public int Sqrt(int num)
        {
            if (num == 0 || num == 1)
            {
                return num;
            }

            int left = 1, right = num, ans = 0;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Avoids potential overflow in (left + right) / 2
                long square = (long)mid * mid; // Prevent integer overflow

                if (square == num)
                {
                    return mid;
                }
                else if (square < num)
                {
                    left = mid + 1;
                    ans = mid; // Store the last valid value
                }
                else
                {
                    right = mid - 1;
                }
            }

            return ans;
        }

        //  You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

        //Merge nums1 and nums2 into a single array sorted in non-decreasing order.

        // The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
        //Function for merging two sorted array.
        public int[] MergeSortedArray(int[] num1, int m, int[] num2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (num1[i] > num2[j])
                {
                    num1[k] = num1[i];
                    i--;
                    k--;
                }
                else
                {
                    num1[k] = num2[j];
                    j--;
                    k--;
                }
            }
            while (j >= 0)
            {
                num1[k] = num2[j];
                k--;
                j--;
            }
            return num1;
        }

        



    }
}
