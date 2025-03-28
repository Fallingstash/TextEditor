using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Linq;

[Serializable]
public class TextFile {
  public string FilePath { get; set; }
  public string Content { get; set; }

  public TextFile() {
    Content = string.Empty;
  }

  public TextFile(string content = "") {
    Content = content;
  }

  public void SerializeToBinary(string filePath) {
    using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
      BinaryFormatter formatter = new BinaryFormatter();
      formatter.Serialize(fs, this);
    }
  }

  public static TextFile DeserializeFromBinary(string filePath) {
    using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
      BinaryFormatter formatter = new BinaryFormatter();
      return (TextFile)formatter.Deserialize(fs);
    }
  }

  public void SerializeToXml(string filePath) {
    using (FileStream fs = new FileStream(filePath, FileMode.Create)) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
      serializer.Serialize(fs, this);
    }
  }

  public static TextFile DeserializeFromXml(string filePath) {
    using (FileStream fs = new FileStream(filePath, FileMode.Open)) {
      XmlSerializer serializer = new XmlSerializer(typeof(TextFile));
      return (TextFile)serializer.Deserialize(fs);
    }
  }
}