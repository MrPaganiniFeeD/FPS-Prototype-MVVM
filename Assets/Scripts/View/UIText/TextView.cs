using TMPro;
using UniRx;
using UnityEngine;
using ViewModel;

namespace View
{
    public class TextView : MonoBehaviour, IView<ITextViewModel>
    {
        private CompositeDisposable _disposable = new CompositeDisposable();
        [SerializeField] private TMP_Text _text;

        public ITextViewModel ViewModel { get; private set; }

        public void Init() { throw new System.NotImplementedException(); }
        public void Init(ITextViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.GetChangeValue().Subscribe(_ => _text.text = _).AddTo(_disposable);
        }
    }
}