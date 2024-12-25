﻿using Spire.Doc;
using Spire.Doc.Documents;

namespace WordReaders.Readers;

public class DocFileReader : IWordReader
{
    public readonly string FilePath;

    public DocFileReader(string filePath)
    {
        FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");

        if (!File.Exists(FilePath))
        {
            throw new FileNotFoundException($"File not found: {FilePath}");
        }
    }

    public IEnumerable<string> Read()
    {
        var words = new List<string>();

        // Создаем документ и загружаем файл
        Document document = new Document();
        document.LoadFromFile(FilePath);

        // Перебираем все параграфы в документе
        foreach (Section section in document.Sections)
        {
            foreach (Paragraph paragraph in section.Paragraphs)
            {
                string text = paragraph.Text.Trim();

                // Пропускаем пустые параграфы
                if (string.IsNullOrWhiteSpace(text))
                    continue;

                // Разделяем текст на слова
                var lineWords = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Проверяем, что в параграфе не более одного слова
                if (lineWords.Length > 1)
                {
                    throw new Exception("The doc file must contain no more than one word per line!");
                }

                // Добавляем слово в список, если оно не пустое
                if (lineWords.Length == 1)
                {
                    words.Add(lineWords[0].Trim());
                }
            }
        }

        return words;
    }
}