using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {
  static void Main(string[] args) {
    Console.WriteLine("Бинарная запись и чтение:");
    TextFile file1 = new TextFile("eeeeee");
    file1.SerializeToBinary("example.bin");
    TextFile loadedBinFile = TextFile.DeserializeFromBinary("example.bin");
    Console.WriteLine(loadedBinFile.Content);

    Console.WriteLine("XML запись и чтение");
    TextFile file = new TextFile("привет111");
    file.SerializeToXml("example.xml");
    TextFile loadedXmlFile = TextFile.DeserializeFromXml("example.xml");
    Console.WriteLine(loadedXmlFile.Content);

    Console.WriteLine("Редактор файла");
    TextEditor editor = new TextEditor();
    editor.OpenFile("text1.txt");
    editor.EditFile("World Hello!!!");
    editor.OutputContent();
    editor.EditFile("New Yourk!!!");
    editor.OutputContent();
    editor.Undo();
    editor.OutputContent();

    Console.WriteLine("Индексер");
    var indexer = new FileIndexer();
    var keywords = new List<string> { "кот", "собака" };
    // Индексируем файлы в текущей папке
    Dictionary<string, List<string>> index = indexer.IndexFiles("C:\\Users\\1500n\\OneDrive\\Рабочий стол\\files_for_search", keywords);
    // Выводим результат
    foreach (var entry in index) {
      Console.WriteLine($"Слово: {entry.Key}");
      Console.WriteLine($"Файлы: {string.Join(", ", entry.Value)}\n");
    }
  }
}
