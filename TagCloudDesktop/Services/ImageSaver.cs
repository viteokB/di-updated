using BitmapSavers;

namespace TagCloudDesktop.Services;

public class ImageSaver(BitmapSaver bitmapSaver)
{
    private readonly BitmapSaver bitmapSaver;

    public void SaveImage(ImageSaveSettings saveSettings)
    {
        //SaveFileDialog saveFileDialog = new SaveFileDialog();
        //saveFileDialog.Filter = "Image files (*.png;*.jpeg;*.bmp;*.emf;*.wmf)|*.png;*.jpeg;*.bmp;*.emf;*.wmf|All files (*.*)|*.*";

        //if (saveFileDialog.ShowDialog() == true)
        //{
        //    string savePath = saveFileDialog.FileName;
        //    try
        //    {
        //        bitmapSaver.Save(saveSettings, );
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка сохранения");
        //    }
        //}
    }
}