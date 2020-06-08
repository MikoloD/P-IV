using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class FileDataProvider : IDataProvider
    {

        public string GetData()
        {
            var path = @"C:\Users\Mikołaj\Desktop\BazaDanych\lab14\data.txt";
            return File.ReadAllText(path);
        }
    }
}
