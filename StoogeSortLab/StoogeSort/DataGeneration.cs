using System.Text;

namespace StoogeSort;


partial class Program
{
    static void GenerateDataIfNotExists()
    {
        if (!Directory.Exists(dataFolder))
            Directory.CreateDirectory(dataFolder);

        // Проверяем, есть ли уже файлы, чтобы не генерировать заново
        var existingFiles = Directory.GetFiles(dataFolder, "data_*.txt");
        if (existingFiles.Length > 0)
        {
            Console.WriteLine("Данные уже существуют. Пропуск генерации.");
            return;
        }

        Console.WriteLine("Генерация входных данных...");
        Random rand = new Random(42); // Фиксированный seed

        // генерируем от 100 до 1500 с шагом 100
        // больше 1500-2000 для Stooge Sort будет очень долго
        for (int size = 100; size <= 1500; size += 100)
        {
            string filePath = Path.Combine(dataFolder, $"data_{size}.txt");
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                sb.AppendLine(rand.Next(0, 1_000).ToString());
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        Console.WriteLine("Данные сгенерированы.");
    }
}