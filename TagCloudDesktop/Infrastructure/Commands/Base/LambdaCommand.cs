namespace TagCloudDesktop.Infrastructure.Commands.Base;

public class LambdaCommand : Command
{
    private readonly Func<object, bool> _CanExecute;
    private readonly Action<object> _Execute;

    public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecure = null)
    {
        _Execute = Execute ?? throw new ArgumentException(nameof(Execute));
        _CanExecute = CanExecure;
    }

    public override bool CanExecute(object? parameter)
    {
        return _CanExecute?.Invoke(parameter) ?? true;
    }

    public override void Execute(object? parameter)
    {
        _Execute(parameter);
    }
}