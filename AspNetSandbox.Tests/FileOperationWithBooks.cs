﻿using System;
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
            File.WriteAllText("newSettings.json", @"{
  ""ConnectionStrings"": {
    ""DefaultConnection"": ""Port=5432; Database=aspnetDB; Host=localhost; User Id=postgres; Password=LukianQwe1; Trust Server Certificate=true"",
    ""Heroku"": ""Server=ec2-44-195-247-84.compute-1.amazonaws.com;Port=5432;Database=d8nkn7e021eal0;User Id=vneponkvjjiqqb;Password=6d2fd7d56fb389fcf4f11c2dffea206a4ca7f6aa898d58ee2db025cfa0081d6d;SSL Mode=Require;Trust Server Certificate=true"",
    ""LocalPostgresConnection"": ""Server=127.0.0.1;Port=5432;Database=aspNetSandbox;User Id=postgres;Password=d34a76;SSL Mode=Require;Trust Server Certificate=true"",
    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox2-C28FE6ED-5E7E-4F9C-ACD2-ADAC955C991B;Trusted_Connection=True;MultipleActiveResultSets=true""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft"": ""Warning"",
      ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
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
