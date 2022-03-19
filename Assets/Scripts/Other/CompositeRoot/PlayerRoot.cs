using Components;
using Infostruct.Data;
using Model;
using Model.StateMachine.Fabric;
using Model.StateMachine.Machine;
using Other.Inventory;
using Player;
using Player.PlayerInputView;
using Player.Weapon.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using View;
using View.Physics;
using ViewModel;
using ViewModel.Physics;

namespace CompositeRoot
{
    public class PlayerRoot : MonoBehaviour, IRoot, IPlayerCompositeRoot
    {
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlayerMovementInputView _playerMovementInputView;
        [SerializeField] private PlayerLookingInputView _lookingInputView;
        [SerializeField] private ClickInputView _clickInputView;
        [SerializeField] private Transform _cameraHolder;
        [FormerlySerializedAs("gamePlayCameraView")] [FormerlySerializedAs("_playerCameraView")] [SerializeField] private GameplayCameraView _gameplayCameraView;
        [SerializeField] private InventoryCompositeRoot _inventoryCompositeRoot;
        [FormerlySerializedAs("_physicsDetectorView")] [SerializeField] private RaycastDetectorView _raycastDetectorView;

        public PlayerModel PlayerModel => _player;
        public PlayerStats PlayerStats => _playerStats;
        public ICameraRotation CameraRotation => _cameraRotation;

        public TransformableViewModel TransformableViewModel => _transformableViewModel;
        
        
        public PlayerView PlayerView => _playerView;
        public GameplayCameraView GameplayCameraView => _gameplayCameraView;
        public InventoryCompositeRoot InventoryCompositeRoot => _inventoryCompositeRoot;


        private IPlayerInputMovementHandlerViewModel _inputMovementViewModel;
        private IPlayerInputLookOnHandlerViewModel _inputLookOnViewModel;
        private IDesiredViewModel _desiredViewModel;
        private TransformableViewModel _transformableViewModel;
        private IClickInputViewModel _clickInputViewModel;

        private PlayerModel _player;
        private PlayerMovement _playerMovement;
        private PlayerShooting _playerShooting;
        private IInventory _inventory;
        private ICameraRotation _cameraRotation;
        private RotationLocal _rotationLocal;
        private IStateMachine _stateMachine;
        private FabricState _fabricState;
        
        
        private CompositeDisposable _disposable = new CompositeDisposable();
        
        public void Init()
        {
            //Model
            _player = new PlayerModel(transform.position, ref _rotationLocal, _playerSettings, _playerStats);
            _cameraRotation = new CameraRotation(_player, _playerSettings);

            _inventoryCompositeRoot.Init();
            _inventory = _inventoryCompositeRoot.Inventory;

            _fabricState = new FabricState(_player, _inventory);
            
            _stateMachine = new StateMachine(_fabricState);
            _playerMovement = new PlayerMovement(_stateMachine);
            _playerShooting = new PlayerShooting(_stateMachine);
            
                if (_cameraRotation is IUpdateable cameraRotation)
                    Observable.EveryUpdate().Subscribe(x =>
                {
                    cameraRotation.FixedUpdate(Time.fixedDeltaTime);
                }).AddTo(_disposable);
            
            if (_player is IUpdateable playerModel)
                Observable.EveryUpdate().Subscribe(x =>
                {
                    playerModel.Update(Time.deltaTime);
                }).AddTo(_disposable);
            
            //ViewModel
            
            _transformableViewModel = new TransformableViewModel(_player);
            _desiredViewModel = new DesiredViewModel(_player);
            _inputMovementViewModel = new PlayerInputMovementViewModel(_playerMovement);
            _inputLookOnViewModel = new PlayerInputLookingViewModel(_cameraRotation);
            _clickInputViewModel = new ClickInputViewModel(_playerShooting);
            
            //View
            _gameplayCameraView.Init();
            _playerView.Init(_transformableViewModel); 
            _playerMovementInputView.Init(_inputMovementViewModel);
            _lookingInputView.Init(_inputLookOnViewModel);
            _clickInputView.Init(_clickInputViewModel);
            _raycastDetectorView.Init(_desiredViewModel);
        }
    }
}