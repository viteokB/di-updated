using WordReaders;
using WordReaders.Factory;

namespace TagCloudDesktop.Services;

public class FileWordReader
{
    private readonly IWordReaderFactory factory;
    private IWordReader wordReader;

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
        //OpenFileDialog fileDialog = new OpenFileDialog();

        //fileDialog.Filter = "Image files (*.doc;*.docx;*.txt)|*.doc;*.docx;*.txt;|All files (*.*)|*.*";

        //if (fileDialog.ShowDialog() == true)
        //{
        //    wordReader = factory.CreateWordReader(fileDialog.FileName);
        //}
    }
}