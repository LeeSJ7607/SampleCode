using UniRx;

public abstract class Model
{
    protected CompositeDisposable _disposable = new CompositeDisposable();

    protected virtual void Disposable()
    {
        _disposable.Clear();
    }
}