using WordReaders.Factory;

namespace WordReaders.Readers;

public class MultiFormatWordReader : IWordReader
{
    private readonly IWordReaderFactory factory;
    private IWordReader wordReader;

    public MultiFormatWordReader(IWordReaderFactory wordReaderFactory)
    {
        factory = wordReaderFactory;
    }

    public IEnumerable<string> Read()
    {
        return wordReader.Read();
    }
}