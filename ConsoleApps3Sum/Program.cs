using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApps3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            Solution s = new Solution();
            var result = s.ThreeSum(nums);
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var listEqCompare = new ListEqCompare();
            HashSet<IList<int>> result = new HashSet<IList<int>>(listEqCompare);
            if(nums.Length>3 && nums.All(x=>x==0))
                return new List<IList<int>>{new List<int>{ 0, 0, 0 } };
            Array.Sort(nums, (i, i1) => i1.CompareTo(i));
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    {
                        int k =
                            Array.BinarySearch(nums, j + 1, nums.Length - j - 1,
                                -(nums[i] + nums[j]), new ComparerDesc());
                        if (k > -1)
                        {
                            result.Add(new List<int> {nums[k], nums[j], nums[i]});
                        }
                    }
                }
            }
            return result.ToList();
        }

        public class ComparerDesc : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x);
            }
        }

        class ListEqCompare : IEqualityComparer<IList<int>>
        {
            public bool Equals(IList<int> x, IList<int> y)
            {
                if (x[2] != y[2])
                    return false;
                if (x[1] != y[1])
                    return false;
                return true;
            }

            public int GetHashCode(IList<int> obj)
            {
                int hash = 0;
                foreach (int num in obj)
                    hash = hash ^ EqualityComparer<int>.Default.GetHashCode(num);

                return hash;
            }
        }
    }
}
