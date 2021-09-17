using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetSandbox2;
using Xunit;

namespace AspNetSandbox.Tests
{
    class StartupTests
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            //Assume

            string databaseUrl = "postgres://lwjdryuypwnqtx:25777239092a93a32507fd67569f37713ced3f9100999432579963c3b231267a@ec2-52-30-81-192.eu-west-1.compute.amazonaws.com:5432/db6v97ok67hpgg";


            //Act

            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            //Assert

            Assert.Equal("Server=ec2-44-195-247-84.compute-1.amazonaws.com;Port=5432;Database=d8nkn7e021eal0;User Id=vneponkvjjiqqb;Password=6d2fd7d56fb389fcf4f11c2dffea206a4ca7f6aa898d58ee2db025cfa0081d6d;SSL Mode=Require;Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
