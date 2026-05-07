using System.Diagnostics;
using System.Text;


namespace StoogeSort;

partial class Program
{
    // Пути для файлов
    static string dataFolder = "TestData";
    static string resultFile = "stooge_results.csv";

    static void Main(string[] args)
    {
        Console.WriteLine("=== STOOGE SORT ANALYSIS ===");

        // генерация данных
        GenerateDataIfNotExists();

        // запуск тестов
        RunTests();

        Console.WriteLine($"Готово! Результаты сохранены в {resultFile}");
        Console.WriteLine("Теперь откройте этот файл в Excel для построения графиков.");
    }
        
    static double MeasureTime(Action action)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        action();
        sw.Stop();
        return sw.Elapsed.TotalMilliseconds;
    }

    static void SaveResult(int size, string type, double time, long iterations)
    {
        using (StreamWriter sw = new StreamWriter(resultFile, true))
        {
            sw.WriteLine($"{size};{type};{time};{iterations}");
        }
    }
}