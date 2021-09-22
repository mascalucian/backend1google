using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{

    public class FileOperationWithBooks
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("README.md", @"Hello");
        }

        [Fact]
        public void AppendFileTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var path = directoryInfo.Parent.Parent.Parent.ToString();
            var path2 = "C:\\git\\backend1google\\AspNetSandbox2";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path2, "README.md"), true))
            {
                outputFile.WriteLine(@"
![alt text](https://i.imgur.com/51RcXRy.jpg)");
            }
        }

        [Fact]
        public void ReadFilesTest()
        {
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var text = temp.GetString(b);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
