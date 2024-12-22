using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.WordReadersTests.FileReaderTests
{
    public abstract class BaseFileReaderTests
    {
        protected const string FILESSAMPLE_DIR_PATH = @"WordReadersTests/FileReaderTests/FilesSample";

        protected abstract string FilesDirectoryName { get; }

        protected string GetFilesParentDir => FILESSAMPLE_DIR_PATH + @$"/{FilesDirectoryName}";

        // Метод для генерации вывода слов
        protected string CreateWordsOutput(IEnumerable<string> words)
        {
            var sb = new StringBuilder();
            bool isFirstWord = true;

            foreach (var word in words)
            {
                if (!isFirstWord)
                {
                    sb.AppendLine();
                }

                sb.Append($"word: '{word}'");
                isFirstWord = false;
            }

            return sb.ToString();
        }
    }
}
