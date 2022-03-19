using System;
using UniRx;

namespace ViewModel.Text
{
    public class TextViewModel : ITextViewModel
    {
        public event Action<string> ChangeAnyValue;

        public ReactiveProperty<string> GetChangeValue()
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}