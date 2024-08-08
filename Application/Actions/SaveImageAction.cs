using di.Infrastructure.UiActions;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;

namespace di.Application.Actions
{
    // Можно сделать в веб морде галлерею и здесь сохранять картику в памяти устройства
    public class SaveImageAction : IApiAction, INeed<IImageDirectoryProvider>
    {
        private IImageDirectoryProvider imageDirectoryProvider;

        public void SetDependency(IImageDirectoryProvider dependency)
        {
            imageDirectoryProvider = dependency;
        }

        // public void Perform()
        // {
        //     var dialog = new SaveFileDialog
        //     {
        //         CheckFileExists = false,
        //         InitialDirectory = Path.GetFullPath(imageDirectoryProvider.ImagesDirectory),
        //         DefaultExt = "bmp",
        //         FileName = "image.bmp",
        //         Filter = "Изображения (*.bmp)|*.bmp" 
        //     };
        //     var res = dialog.ShowDialog();
        //     if (res == DialogResult.OK)
        //         imageHolder.SaveImage(dialog.FileName);
        // }

        public string Endpoint => "/gallery";
        public string HttpMethod => "POST";
        public int Perform(Stream inputStream, Stream outputStream)
        {
            throw new NotImplementedException();
        }
    }
}