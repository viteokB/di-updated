using WordHandlers.MyStem;
using WordHandlers.MyStem.InfoClasses;

namespace WordHandlers.Handlers
{
    public class BoringWordHandler : IWordHandler, IDisposable
    {
        private static readonly MyStemAnalyzer myStemAnalyzer = new MyStemAnalyzer();

        private bool disposed = false;

        //В принципе лего можно добавить настройку пользователем(мне не интересно)
        private static HashSet<PartOfSpeech> notBoringPartOfSpeeches = NotBoringConfiguration.NotBoringPartOfSpeeches;

        private static bool IsNotBoringWord(WordInfo wordInfo)
        {
            return notBoringPartOfSpeeches.Contains(wordInfo.PartOfSpeech);
        }

        public static IEnumerable<string> ApplyWordHandler(IEnumerable<string> words)
        {
            if (words == null)
            {
                return Enumerable.Empty<string>(); // Обрабатываем null-аргумент
            }

            return myStemAnalyzer
                .AnalyzeWords(words)
                .Where(IsNotBoringWord)
                .Select(wordInfo => wordInfo.Lemma)
                .ToHashSet(); // Используем ToHashSet() чтобы избежать дубликатов и сразу получить HashSet
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    myStemAnalyzer.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BoringWordHandler()
        {
            Dispose(false);
        }
    }
}
