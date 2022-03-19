using System;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Model;
using Player.Weapon.Recoil;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


namespace Trail
{
    public class RecoilMonobehFIRstTRAIL : MonoBehaviour
    {
        [SerializeField] private RecoilInfo _recoilInfo;
        [SerializeField] private AnimationCurve _curve;
        [FormerlySerializedAs("_transform")] [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _playerTransform;

        private float _curveT;
        private float _recoilValue;
        private PlayerInput _playerInput;

        [SerializeField] private float _currentRecoilXPos;
        [SerializeField] private float _currentRecoilYPos;
        [SerializeField] private float _recoilAmountX;
        [SerializeField] private float _recoilAmountY;
        [SerializeField] private float _timePressed;
        [SerializeField] private float _maxRecoilTime;

        private RotationLocal _rotationLocal = new RotationLocal();

        private int _currentCartridge;

        private Vector3 _currentRotation;
        private Vector3 _targetRotation; 

        [SerializeField] private float _recoilX;     
        [SerializeField] private float _recoilY;

        [SerializeField] private float _snappines;
        [SerializeField] private float _returnSpeed;
        
        private float _wantedYRotation;
        private float _wantedCameraXRotation;
        
        private float _rotationYVelocity;
        private float _cameraXVelocity;
        private float _yRotationSpeed;
        private float _xCameraSpeed;

        private float _currentYRotation;
        private float _currentCameraXRotation;
        
        private bool _isShoot = true;

        
        private void Start()
        {
            _playerInput = new PlayerInput();
            _playerInput.Enable();
            //_playerInput.OnFoot.Look.performed += LookOnMouse;
            _xCameraSpeed = 0.01f;
            _yRotationSpeed = 0.01f;
        }

        private void Update()
        {
            if (_playerInput.OnFoot.LeftClick.inProgress)
                Recoil30();
            
            LookOnMouseVector(_playerInput.OnFoot.Look.ReadValue<Vector2>());
            
            
            _currentYRotation = Mathf.SmoothDamp( _currentYRotation,
                _wantedYRotation,
                ref _rotationYVelocity, _yRotationSpeed);

            _currentCameraXRotation = Mathf.SmoothDamp(_currentCameraXRotation,
                _wantedCameraXRotation,
                ref _cameraXVelocity,
                _xCameraSpeed);
            _playerTransform.localRotation = Quaternion.Euler(_currentRotation);
        }

        private void LookOnMouseVector(Vector2 direction)
        {
            _wantedYRotation = direction.x * Time.deltaTime * 10;
            _wantedCameraXRotation -= direction.y * Time.deltaTime * 10;
            //_playerTransform.Rotate(Vector3.up * _wantedYRotation);

            _targetRotation += Vector3.up * _wantedYRotation;
            _wantedCameraXRotation = Mathf.Clamp(_wantedCameraXRotation, -90, 60);
            _cameraTransform.localRotation = Quaternion.Euler(_wantedCameraXRotation, 0f, 0f);
            //_targetRotation += new Vector3(_wantedCameraXRotation, 0f);
        }

        private void LookOnMouse(Vector2 direction)
        {
            _wantedYRotation += direction.x * Time.deltaTime * 10;
            _wantedCameraXRotation -= direction.y * Time.deltaTime * 10;
            

            _currentYRotation = Mathf.SmoothDamp( _currentYRotation,
                _wantedYRotation,
                ref _rotationYVelocity, _yRotationSpeed);

            _currentCameraXRotation = Mathf.SmoothDamp(_currentCameraXRotation,
                _wantedCameraXRotation,
                ref _cameraXVelocity,
                _xCameraSpeed);
            
            //Debug.Log($"{rotationLocal.X} || {rotationLocal.Y}");
            //Debug.Log($"X {rotationLocal.X} || Y {rotationLocal.Y} || Z {rotationLocal.Z}");

            _cameraTransform.localRotation = Quaternion.Euler(_currentCameraXRotation, 0, 0);
            _playerTransform.rotation = Quaternion.Euler(0, _currentYRotation, 0);
            
        }

        private void Recoil20(InputAction.CallbackContext obj)
        {
            _currentCartridge++;
            if (_currentCartridge > _recoilInfo.Points.Count() - 1)
            {
                Debug.Log("not recoil Points");
                _currentCartridge = 0;
                _currentRecoilXPos = 0;
                _currentRecoilYPos = 0;
                return;
            }

            Debug.Log(_currentCartridge);
            var currentRecoilPoint = _recoilInfo.Points.ElementAt(_currentCartridge);

            _currentRecoilXPos -= (currentRecoilPoint / 2) * _recoilAmountX;
            _currentRecoilYPos -= (currentRecoilPoint / 2) * _recoilAmountY;

            var wantedCameraXRotation = 0f;
            var wantedYRotation = 0f;
            wantedCameraXRotation -= Mathf.Abs(_currentRecoilYPos);
            wantedYRotation -= _currentRecoilYPos;
            
            _cameraTransform.localRotation = Quaternion.Euler( _currentRecoilYPos, _currentRecoilXPos,0);

        }

        private void Recoil30()
        {
            if(_isShoot == false)
                return;
            _currentCartridge++;
            if (_currentCartridge > _recoilInfo.Points.Count() - 1)
            {
                _currentCartridge = 0;
                return;
            }
            TEST();
            var recoilPoint = _recoilInfo.Points.ElementAt(_currentCartridge);
            _currentRecoilXPos = _recoilX;
            _currentRecoilYPos = recoilPoint * _recoilY;
            
            _targetRotation += new Vector3(_currentRecoilXPos, _currentRecoilYPos);
        }

        private void Recoil40()
        {
            if(_isShoot == false)
                return;
            _currentCartridge++;
            if (_currentCartridge > _recoilInfo.Points.Count() - 1)
            {
                _currentCartridge = 0;
                return;
            }

            TEST();
            var recoilPoint = _recoilInfo.Points.ElementAt(_currentCartridge);
            _currentRecoilXPos = _recoilX * recoilPoint;
            _currentRecoilYPos = _recoilY;
            _xCameraSpeed = +0.01f;
            _cameraXVelocity = +0.01f;
            _wantedCameraXRotation -= Mathf.Abs(_currentRecoilYPos);
            _wantedYRotation -= _currentRecoilXPos;
        }
        private async void TEST()
        {
            _isShoot = false; 
            await Task.Delay(200);
            _isShoot = true;
        }
        private void OnDisable()
        {
         //   _playerInput.OnFoot.Look.performed -= LookOnMouse;
         //   _playerInput.OnFoot.LeftClick.performed -= Recoil40;
        }
    }
}