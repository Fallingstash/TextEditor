using System;

public class Memento {
  public string FilePath { get; }
  public string Content { get; }

  public Memento(string filePath, string content) {
    FilePath = filePath;
    Content = content;
  }
}
