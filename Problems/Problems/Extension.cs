using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class Extension
    {
        private static Extension? instance;
        public static Extension GetInstance()
        {
            if(instance == null)
            {
                instance = new Extension();
            }
            return instance;
        }
        public int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
        public int[] Sort2DArray(int[,] nums)
        {
            List<int> result = new();
            foreach (int i in nums)
            {
                result.Add(i);
            }
            var returnArray = result.ToArray();
            Array.Sort(returnArray);
            return returnArray;
        }
        public bool CheckOdd(int num)
        {
            if (num % 2 == 1)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
