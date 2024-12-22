namespace WordHandlers
{
    public interface IWordHandler
    {
        public static abstract IEnumerable<string> ApplyWordHandler(IEnumerable<string> words);
    }
}
