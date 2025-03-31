using System;

public class Memento { //поменял мементо
  public string FilePath { get; }
  public string Content { get; }

  public Memento(string filePath, string content) {
    FilePath = filePath;
    Content = content;
  }
}
