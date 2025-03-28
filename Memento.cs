using System;
using System.Collections.Generic;
using System.IO;

public class Memento {
  public TextFile currentFile;
  public Stack<TextFile> history = new Stack<TextFile>();
  public void SaveFile() {
    File.WriteAllText(currentFile.FilePath, currentFile.Content);
  }

  public void SaveState() {
    history.Push(new TextFile {
      FilePath = currentFile.FilePath,
      Content = currentFile.Content
    });
  }

  public void Undo() {
    if (history.Count > 0) {
      currentFile = history.Pop();
      SaveFile();
    }
  }
}
