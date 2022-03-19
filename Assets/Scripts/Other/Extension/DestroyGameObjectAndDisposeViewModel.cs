using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using ViewModel;

public static class DestroyGameObjectAndDisposeViewModel
{
    private static CompositeDisposable _disposable = new CompositeDisposable();

    public static void DisposeOnDestroy<T, S>(this T view, ref S viewModel) where T : Component
                                                                            where S : IDisposable
    {
        view.OnDisableAsObservable().Subscribe(x =>
        {
        }).AddTo(_disposable);
    }
}
