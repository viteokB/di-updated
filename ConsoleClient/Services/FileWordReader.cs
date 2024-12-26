using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordReaders;
using WordReaders.Factory;

namespace ConsoleClient.Services
{
    public class FileWordReader
    {
        private IWordReader wordReader;
        private readonly IWordReaderFactory factory;

        public FileWordReader(IWordReaderFactory wordReaderFactory)
        {
            factory = wordReaderFactory;
        }

        public IEnumerable<string> Read()
        {
            return wordReader.Read();
        }
    }
}
