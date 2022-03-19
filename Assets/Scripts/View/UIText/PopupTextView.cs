using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using ViewModel;

namespace View
{
    public class PopupTextView : MonoBehaviour, IView<IViewModel>
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _duration;
        
        public IViewModel ViewModel { get; }

        public void Init() { }

        public void Activate()
        {
            LifeCycle();
        }
        public void SetText(string text)
        {
            _text.text = text;
        }

        private async void LifeCycle()
        {
            var timer = 0f;
            while(timer < 1f)
            {
                timer = Mathf.Min(timer + Time.deltaTime / _duration, 1f);
                await Task.Yield();
            }
            gameObject.SetActive(false);
        }
    }
}