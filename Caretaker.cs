using System.Collections.Generic;
using System.IO;

public class Caretaker {
  public TextFile currentFile;
  private Stack<Memento> history = new Stack<Memento>();

  public void SaveFile() {
    File.WriteAllText(currentFile.FilePath, currentFile.Content);
  }

  public void SaveState() {
    history.Push(new Memento(currentFile.FilePath, currentFile.Content));
  }

  public void Undo() {
    if (history.Count > 0) {
      var lastState = history.Pop();
      currentFile.FilePath = lastState.FilePath;
      currentFile.Content = lastState.Content;
      SaveFile(); 
    }
  }
}