using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class TextFileSearcher {
  public List<string> SearchFiles(string directoryPath, List<string> keywords) {
    List<string> foundFiles = new List<string>();

    foreach (string filePath in Directory.GetFiles(directoryPath, "*txt", SearchOption.AllDirectories)) {
      string content = File.ReadAllText(filePath);

      if (keywords.Any(keyword => content.Contains(keyword))) {
        foundFiles.Add(filePath);
      }
    }

    return foundFiles;
  }
}