namespace CombSort;

partial class Program
{
    static void RunTests()
    {
        // Заголовок CSV
        using (StreamWriter sw = new StreamWriter(resultFile, false))
        {
            sw.WriteLine("Size;Type;TimeMs;Iterations");
        }

        var files = Directory.GetFiles(dataFolder, "data_*.txt").OrderBy(f => f).ToList();

        foreach (var file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            int size = int.Parse(fileName.Split('_')[1]);

            Console.WriteLine($"Обработка размера: {size}");

            // Чтение данных
            string[] lines = File.ReadAllLines(file);
                
            // Подготовка Array
            int[] arrData = lines.Select(int.Parse).ToArray();
                
            // Подготовка List
            List<int> listData = new List<int>(arrData);

            // 1. Тест Array
            long iterArray = 0;
            double timeArray = MeasureTime(() => CombSortArray(arrData, ref iterArray));
            SaveResult(size, "Array", timeArray, iterArray);
            Console.WriteLine($"  Array: {timeArray:F4} ms, Iter: {iterArray}");

            // 2. Тест List
            long iterList = 0;
            double timeList = MeasureTime(() => CombSortList(listData, ref iterList));
            SaveResult(size, "List", timeList, iterList);
            Console.WriteLine($"  List : {timeList:F4} ms, Iter: {iterList}");
        }
    }
}