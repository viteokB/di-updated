using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordReaders;
using WordReaders.Factory;

namespace TagCloudDesktop.Services
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

        public void OpenFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image files (*.doc;*.docx;*.txt)|*.doc;*.docx;*.txt;|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == true)
            {
                wordReader = factory.CreateWordReader(fileDialog.FileName);
            }
        }
    }
}
