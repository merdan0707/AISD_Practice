namespace StoogeSort;

partial class Program
{
    // for array
    static void StoogeSortArray(int[] arr, ref long iterations)
    {
        StoogeSortArrayRecursive(arr, 0, arr.Length - 1, ref iterations);
    }

    static void StoogeSortArrayRecursive(int[] arr, int left, int right, ref long iterations)
    {
        iterations++; // считаем рекурсии

        if (arr[left] > arr[right])
        {
            (arr[left], arr[right]) = (arr[right], arr[left]);
        }

        if (right - left + 1 >= 3)
        {
            int t = (right - left + 1) / 3;
            StoogeSortArrayRecursive(arr, left, right - t, ref iterations);
            StoogeSortArrayRecursive(arr, left + t, right, ref iterations);
            StoogeSortArrayRecursive(arr, left, right - t, ref iterations);
        }
    }

    // for List<T>
    static void StoogeSortList(List<int> list, ref long iterations)
    {
        StoogeSortListRecursive(list, 0, list.Count - 1, ref iterations);
    }

    static void StoogeSortListRecursive(List<int> list, int left, int right, ref long iterations)
    {
        iterations++;

        if (list[left] > list[right])
        {
            (list[left], list[right]) = (list[right], list[left]);
        }

        if (right - left + 1 >= 3)
        {
            int t = (right - left + 1) / 3;
            StoogeSortListRecursive(list, left, right - t, ref iterations);
            StoogeSortListRecursive(list, left + t, right, ref iterations);
            StoogeSortListRecursive(list, left, right - t, ref iterations);
        }
    }
}