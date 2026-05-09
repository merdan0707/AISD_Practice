namespace CombSort;

partial class Program
{
        // Comb Sort для массива
        static void CombSortArray(int[] arr, ref long iterations)
        {
            if (arr == null || arr.Length == 0) return;

            int gap = arr.Length;
            double shrinkFactor = 1.247330950103979; // Оптимальный коэффициент сжатия
            bool sorted = false;

            while (!sorted)
            {
                // Уменьшаем зазор
                gap = (int)(gap / shrinkFactor);
                if (gap <= 1)
                {
                    gap = 1;
                    sorted = true; // Последний проход (как пузырек)
                }

                // Проход по массиву с текущим зазором
                for (int i = 0; i + gap < arr.Length; i++)
                {
                    iterations++; // Каждое сравнение считаем за итерацию
                    
                    if (arr[i] > arr[i + gap])
                    {
                        // Swap
                        (arr[i], arr[i + gap]) = (arr[i + gap], arr[i]);
                        sorted = false; // Если была замена, массив еще не готов
                    }
                }
            }
        }

        // Comb Sort для List<T>
        static void CombSortList(List<int> list, ref long iterations)
        {
            if (list == null || list.Count == 0) return;

            int gap = list.Count;
            double shrinkFactor = 1.247330950103979;
            bool sorted = false;

            while (!sorted)
            {
                gap = (int)(gap / shrinkFactor);
                if (gap <= 1)
                {
                    gap = 1;
                    sorted = true;
                }

                for (int i = 0; i + gap < list.Count; i++)
                {
                    iterations++;
                    
                    if (list[i] > list[i + gap])
                    {
                        (list[i], list[i + gap]) = (list[i + gap], list[i]);
                        sorted = false;
                    }
                }
            }
        }
}