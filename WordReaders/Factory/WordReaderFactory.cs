using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WordReaders.Readers;

namespace WordReaders.Factory
{
    public class WordReaderFactory : IWordReaderFactory
    {
        public IWordReader CreateWordReader(string filePath)
        {
            return Path.GetExtension(filePath).ToLower() switch
            {
                ".txt" => new FileReader(filePath, Encoding.UTF8),
                ".docx" => new DocxFileReader(filePath),
                ".doc" => new DocFileReader(filePath),
                _ => throw new ArgumentOutOfRangeException(nameof(filePath), filePath, "Unsupported file type")
            };
        }
    }
}
