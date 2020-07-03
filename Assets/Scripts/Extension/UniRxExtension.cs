using System;
using UniRx;

public static class UniRxExtension
{
    public static IDisposable SubscribeAndActionInvoke<T>(this IObservable<T> this_, Action<T> act_, T value_)
    {
        if (this_ == null || act_ == null)
            return null;

        act_.Invoke(value_);
        return this_.Subscribe(_ => act_.Invoke(value_));
    }
}