using CompositeRoot.UI;
using Model;
using Player;
using Player.Model.Stats.StatViewModel;
using Player.Stats;
using Player.Weapon.ViewModel;
using UnityEngine;
using UnityEngine.Serialization;
using View.Transformable;
using View.UIText.DamageUI;
using ViewModel;
using ViewModel.Damageble;
using ViewModel.Physics;
using Zenject;

namespace CompositeRoot.Environment
{
    public class TargetCompositeRoot : MonoBehaviour, IRoot
    {
        [SerializeField] private int _health;
        [SerializeField] private DamageHitView _damageHitView;
        [SerializeField] private DamageHitAudioView _audioView;
        [FormerlySerializedAs("_transformableView")] [SerializeField] private TransformableStaticObjectView transformableStaticObjectView;
        private DamageHitUIContainer _damageHitUIContainer;
        private GameplayCameraView _gameplayCamera;
        private Transform _transform;

        private ITextViewModel _textViewModel;
        private ITransformableViewModel _transformableViewModel;
        private IDesiredViewModel _desiredViewModel;
        private IDamageableViewModel _damageableViewModel;

        private Target _target;

        [Inject]
        public void Construct(GameplayCameraView gameplayCameraView, DamageHitUIContainer damageUIContainer)
        {
            _gameplayCamera = gameplayCameraView;
            _damageHitUIContainer = damageUIContainer;
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            Init();
        }

        public void Init()
        {
            //model
            var position = _transform.position;
            _target = new Target(position, 
                new RotationLocal(0,0,0), new Health("Health", _health));
            
            //viewModel
            _desiredViewModel = new DesiredViewModel(_target);
            _transformableViewModel = new TransformableViewModel(_target);
            _textViewModel = new DamageableViewModel(_target);
            _damageableViewModel = new DamageableViewModel(_target);
            //view
            _audioView.Init(_damageableViewModel);
            transformableStaticObjectView.Init(_transformableViewModel, _gameplayCamera);        
            _damageHitView.Init(_textViewModel, _desiredViewModel, _damageHitUIContainer.transform, _gameplayCamera);
        }
    }
}