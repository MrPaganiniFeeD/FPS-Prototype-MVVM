using System;
using Other.Pool.Mono;
using UniRx;
using UnityEngine;
using View.Physics;
using ViewModel;
using ViewModel.Physics;
using Random = UnityEngine.Random;

namespace View.UIText.DamageUI
{
    public class DamageHitView : MonoBehaviour, IView<ITextViewModel>, IRaycastDetectorView
    {
        [SerializeField] private PopupTextView _popupPrefab;
        [SerializeField] private float _randomHitPositionRangeX;
        [SerializeField] private float _randomHitPositionRangeY;
        
        
        public ITextViewModel ViewModel { get; private set; }
        private IDesiredViewModel _desiredViewModel;
        private PoolMono<PopupTextView> _pool;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private RaycastHit _currentHit;
        private GameplayCameraView _gameplayCameraView;
        
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(ITextViewModel textViewModel,IDesiredViewModel desiredViewModel,
            Transform container, GameplayCameraView gameplayCameraView)
        {
            ViewModel = textViewModel;
            _desiredViewModel = desiredViewModel;
            _pool = new PoolMono<PopupTextView>(_popupPrefab, 200, true, container);
            _gameplayCameraView = gameplayCameraView;
            ViewModel.ChangeAnyValue += CreatePopup;
        }
        private void CreatePopup(string text)
        {
            var createdPopup = _pool.GetFreeElement();
            createdPopup.Activate();
            var hitPosition = _currentHit.point + GetRandomHitPosition();
            hitPosition = _gameplayCameraView.Camera.WorldToScreenPoint(hitPosition);
            hitPosition.z = 0f;
            createdPopup.transform.position = hitPosition;
            createdPopup.SetText('-' + text);
        }

        private Vector3 GetRandomHitPosition()
        {
            return new Vector3(Random.Range(0, _randomHitPositionRangeX), Random.Range(0, _randomHitPositionRangeY), 0);
        }
        public bool TryGetModelType<T>(out T searchableType)
        {
            return _desiredViewModel.TryCheckTypeModel(out searchableType);
        }

        public void SetHit(RaycastHit hit)
        {
            _currentHit = hit;
        }

        private void OnDestroy()
        {
            ViewModel.ChangeAnyValue -= CreatePopup;
            ViewModel.Dispose();
            ViewModel = null;
        }
    }
}