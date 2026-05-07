namespace StoogeSort;

partial class Program
{
    static void RunTests()
    {
        // Очищаем файл результатов и пишем заголовок
        using (StreamWriter sw = new StreamWriter(resultFile, false))
        {
            sw.WriteLine("Size;Type;TimeMs;Iterations");
        }

        var files = Directory.GetFiles(dataFolder, "data_*.txt").OrderBy(f => f).ToList();

        foreach (var file in files)
        {
            // Извлекаем размер из имени файла (data_100.txt -> 100)
            string fileName = Path.GetFileNameWithoutExtension(file);
            int size = int.Parse(fileName.Split('_')[1]);

            Console.WriteLine($"Обработка размера: {size}");

            // Чтение данных из файла (это НЕ входит в замер времени алгоритма)
            string[] lines = File.ReadAllLines(file);

            // Подготовка данных для Array
            int[] arrData = lines.Select(int.Parse).ToArray();

            // Подготовка данных для List
            List<int> listData = new List<int>(arrData);

            // 1. Тест для Array
            long iterArray = 0;
            double timeArray = MeasureTime(() => StoogeSortArray(arrData, ref iterArray));
            SaveResult(size, "Array", timeArray, iterArray);
            Console.WriteLine($"  Array: {timeArray:F4} ms, Iterations: {iterArray}");

            // 2. Тест для List
            long iterList = 0;
            double timeList = MeasureTime(() => StoogeSortList(listData, ref iterList));
            SaveResult(size, "List", timeList, iterList);
            Console.WriteLine($"  List : {timeList:F4} ms, Iterations: {iterList}");
        }
    }
}