namespace WordHandlers.Handlers
{
    public class LowercaseWordHandler : IWordHandler
    {
        public static IEnumerable<string> ApplyWordHandler(IEnumerable<string> words)
        {
            return words.Select(w => w.ToLower());
        }
    }
}
