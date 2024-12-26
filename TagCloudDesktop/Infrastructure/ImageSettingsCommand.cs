using TagCloudDesktop.Infrastructure.Commands.Base;
using TagCloudDesktop.ViewModels;

namespace TagCloudDesktop.Infrastructure;

public class ImageSettingsCommand : Command
{
    private readonly ImageSettingsVM viewModel;

    public ImageSettingsCommand(ImageSettingsVM viewModel)
    {
    }

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
    }
}