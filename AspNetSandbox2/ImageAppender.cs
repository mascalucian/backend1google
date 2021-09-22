using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox2
{
    public class ImageAppender
    {


        public void AppendFileTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var path = directoryInfo.Parent.Parent.Parent.ToString();
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "README.md"), true))
            {
                outputFile.WriteLine("appended text");
            }
        }
    }
}
