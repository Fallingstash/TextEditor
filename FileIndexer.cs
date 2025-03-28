using System;
using System.Collections.Generic;

public class FileIndexer {
  private TextFileSearcher searcher = new TextFileSearcher();

  public Dictionary<string, List<string>> IndexFiles(string directory, List<string> keywords) {
    var index = new Dictionary<string, List<string>>();

    foreach (string keyword in keywords) {
      var files = searcher.SearchFiles(directory, new List<string> { keyword });
      index[keyword] = files;
    }

    return index;
  }
}