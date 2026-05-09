using System.Text;

namespace CombSort;

partial class Program
{
    static void GenerateDataIfNotExists()
    {
        if (!Directory.Exists(dataFolder))
            Directory.CreateDirectory(dataFolder);

        var existingFiles = Directory.GetFiles(dataFolder, "data_*.txt");
        if (existingFiles.Length > 0)
        {
            Console.WriteLine("Данные уже существуют. Пропуск генерации.");
            return;
        }

        Console.WriteLine("Генерация входных данных (до 10 000 элементов)...");
        Random rand = new Random(42); 
            
        // Генерируем от 100 до 10 000 с шагом 500 (чтобы точек было около 20-40, либо шаг 100 для 100 точек)
        // Для плавности графика возьмем шаг 200 (получится 50 наборов)
        for (int size = 100; size <= 10_000; size += 200)
        {
            string filePath = Path.Combine(dataFolder, $"data_{size}.txt");
            StringBuilder sb = new StringBuilder();
                
            for (int i = 0; i < size; i++)
            {
                sb.AppendLine(rand.Next(0, 100_000).ToString());
            }
                
            File.WriteAllText(filePath, sb.ToString());
        }
        Console.WriteLine("Данные сгенерированы.");
    }
}