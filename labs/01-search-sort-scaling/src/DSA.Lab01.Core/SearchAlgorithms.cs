using System;

namespace DSA.Lab01
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] values, int target)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] sortedValues, int target)
        {
            if (sortedValues == null)
            {
                throw new ArgumentNullException(nameof(sortedValues));
            }

            int low = 0;
            int high = sortedValues.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (sortedValues[mid] == target)
                {
                    return mid;
                }
                if (sortedValues[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }

                
            }
            


           
            return -1;
        }
    }
}
