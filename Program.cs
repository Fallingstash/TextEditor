using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {
  static void Main(string[] args) {
    Console.WriteLine("Добро пожаловать!!! Выберите действие:");
    Console.WriteLine("1. Запись или чтение файла XML/BIN");
    Console.WriteLine("2. Редактор файла");
    Console.WriteLine("3. Выполнить поиск по ключевым словам...");

    string userChoice = Console.ReadLine();
    switch (userChoice) {
      case "1":
        Console.WriteLine("Вы выбрали запись или чтение файла XML/BIN");
        Console.WriteLine("1. Запись BIN");
        Console.WriteLine("2. Чтение BIN");
        Console.WriteLine("3. Запись XML");
        Console.WriteLine("4. Чтение XML");
        string userChoice1 = Console.ReadLine();

        if (userChoice1 == "1") {
          Console.WriteLine("Вы выбрали запись в BIN, пожалуйста введите текст файла:");
          string dataFile = Console.ReadLine();
          TextFile file1 = new TextFile(dataFile);

          Console.WriteLine("Отлично, теперь укажите название файла :)");
          string fileName = Console.ReadLine();
          file1.SerializeToBinary(fileName);
          Console.WriteLine($"Записано в файл {fileName}!");
        } else if (userChoice1 == "2") {
          Console.WriteLine("Вы выбрали чтение из BIN, пожалуйста введите путь к файлу:");
          string fileName = Console.ReadLine();
          TextFile file1 = TextFile.DeserializeFromBinary(fileName);
          Console.WriteLine("Содержимое файла:");
          Console.WriteLine(file1.Content);
        } else if (userChoice1 == "3") {
          Console.WriteLine("Вы выбрали запись в XML, пожалуйста введите текст файла:");
          string dataFile = Console.ReadLine();
          TextFile file1 = new TextFile(dataFile);

          Console.WriteLine("Отлично, теперь укажите название файла :)");
          string fileName = Console.ReadLine();
          file1.SerializeToXml(fileName);
          Console.WriteLine($"Записано в файл {fileName}!");
        } else if (userChoice1 == "4") {
          Console.WriteLine("Вы выбрали чтение из XML, пожалуйста введите путь к файлу:");
          string fileName = Console.ReadLine();
          TextFile file1 = TextFile.DeserializeFromXml(fileName);
          Console.WriteLine("Содержимое файла:");
          Console.WriteLine(file1.Content);

        } else {
          Console.WriteLine("Неверный выбор.");
        }
        break;

      case "2":
        Console.WriteLine("Редактор файла");
        TextEditor editor = new TextEditor();
        Console.WriteLine("Введите путь к файлу");
        string filePath = Console.ReadLine();
        editor.OpenFile(filePath);

        while (true) {
          Console.WriteLine("1. Редактировать файл");
          Console.WriteLine("2. Откатить изменения");
          Console.WriteLine("3. Вывести содержимое файла");
          Console.WriteLine("4. Выйти");
          string userChoice2 = Console.ReadLine();
          if (userChoice2 == "4") {
            break;
          } else if (userChoice2 == "1") {
            Console.WriteLine("Введите текст, чтобы заменить содержимое файла");
            string dataTxtFile = Console.ReadLine();
            editor.EditFile(dataTxtFile);

          } else if (userChoice2 == "2") {
            editor.Undo();

          } else if (userChoice2 == "3") {
            editor.OutputContent();
          } else {
            Console.WriteLine("Неверный выбор");
          }
        }
        break;

      case "3":
        Console.WriteLine("Поиск по ключевым словам..");
        var indexer = new FileIndexer();

        Console.WriteLine("Введите кол-во ключевых слов");
        int countKeywords = Convert.ToInt32(Console.ReadLine());
        var keywords = new List<string>();

        Console.WriteLine("Введите ключевые слова по очереди.");
        string keyword;
        for (int count = 0; count < countKeywords; ++count) {
          keyword = Console.ReadLine();
          keywords.Add(keyword);
        }

        Console.WriteLine("Введите путь к директории");
        string dirPath = Console.ReadLine();
        Dictionary<string, List<string>> index = indexer.IndexFiles(dirPath, keywords);

        Console.WriteLine("Найденные файлы:");
        foreach (var entry in index) {
          Console.WriteLine($"Слово: {entry.Key}");
          Console.WriteLine($"Файлы: {string.Join(", ", entry.Value)}\n");
        }
        break;
    }
  }
}
