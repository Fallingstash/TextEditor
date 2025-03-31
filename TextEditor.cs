using System;
using System.Collections.Generic;
using System.IO;

public class TextEditor : Caretaker { //теперь наследуется от caretaker'a
  public void OpenFile(string filePath) {
    currentFile = new TextFile { FilePath = filePath, Content = File.ReadAllText(filePath) };
    SaveState();
  }

  public void EditFile(string newContent) {
    SaveState();
    currentFile.Content = newContent;
  }

  public void OutputContent() {
    Console.WriteLine(currentFile.Content);
  }
}