using System;
using System.IO;
using System.Text;

#region Get file info.
Console.WriteLine("== CONVERT GB2312 ENCODING TO UTF8 ==");

Console.WriteLine("Please input a path that storage the data file.");
var basePath = Console.ReadLine() ?? Environment.CurrentDirectory;

Console.WriteLine("Please input the name of the file.");
var fileName = Console.ReadLine() ?? throw new Exception("Error input value.");
var filePath = Path.Combine(basePath, fileName);

if (!File.Exists(filePath)) throw new FileNotFoundException($"Can not found file:{filePath}");
var fileInfo = new FileInfo(filePath);
#endregion

#region Read file content.
Console.WriteLine("Start read file{0}", fileInfo.FullName);
var content = await File.ReadAllTextAsync(filePath, Encoding.GetEncoding("GB2312"));
var newFilePath = Path.Combine(Environment.CurrentDirectory, fileInfo.Name + "-utf8" + fileInfo.Extension);
#endregion

#region Write file in UTF-8.
Console.WriteLine("Output UTF-8 encoding content to file{0}", filePath);
await File.WriteAllTextAsync(newFilePath, content, Encoding.UTF8);
#endregion
