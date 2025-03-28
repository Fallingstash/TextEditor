using System;
using System.Collections.Generic;
using System.IO;

public class TextEditor {
  private TextFile currentFile;
  private Stack<TextFile> history = new Stack<TextFile>();

  public void OpenFile(string filePath) {
    currentFile = new TextFile { FilePath = filePath, Content = File.ReadAllText(filePath) };
    SaveState();
  }

  public void EditFile(string newContent) {
    SaveState();
    currentFile.Content = newContent;
  }

  public void SaveFile() {
    File.WriteAllText(currentFile.FilePath, currentFile.Content);
  }

  private void SaveState() {
    history.Push(new TextFile {
      FilePath = currentFile.FilePath,
      Content = currentFile.Content
    });
  }

  public void Undo() {
    if (history.Count > 0) {
      currentFile = history.Pop();
      SaveFile(); // Сохраняем откат в файл
    }
  }

  public void OutputContent() {
    Console.WriteLine(currentFile.Content);
  }
}