using System.Diagnostics;
using System.Text;

namespace CombSort;

    public static partial class Program
    {
        // Пути для файлов
        static string dataFolder = "TestData_Comb";
        static string resultFile = "comb_results.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("=== COMB SORT ANALYSIS ===");
            
            // 1. Генерация данных
            GenerateDataIfNotExists();

            // 2. Запуск тестов
            RunTests();

            Console.WriteLine($"Готово! Результаты сохранены в {resultFile}");
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