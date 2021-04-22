using System;
using System.Data;
using System.IO;
using System.Text;

// Get file info.
Console.WriteLine("Please input a file name. The file and this program must in a same dir.");
var filename = Console.ReadLine() ?? throw new NoNullAllowedException();
var filePath = Path.Combine(Environment.CurrentDirectory, filename);
var fileInfo = new FileInfo(filePath);

// Read file content.
Console.WriteLine("Start read file{0}", fileInfo.FullName);
var content = await File.ReadAllTextAsync(filename, Encoding.GetEncoding("GBK"));
var newFilePath = Path.Combine(Environment.CurrentDirectory, fileInfo.Name + "-utf8" + fileInfo.Extension);

// Write file in UTF-8.
Console.WriteLine("Output UTF-8 encoding content to file{0}");
await File.WriteAllTextAsync(newFilePath, content, Encoding.UTF8);