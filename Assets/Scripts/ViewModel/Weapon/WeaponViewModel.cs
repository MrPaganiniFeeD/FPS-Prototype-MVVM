using System;
using UniRx;

namespace Player.Weapon.ViewModel
{
    public class WeaponViewModel : IWeaponViewModel, IDisposable
    {
        public event Action Shoot;
        public event Action Reload;
        public event Action Scope;
        
        private IWeapon _weapon;
        private ReactiveProperty<string> _currentCartridge = new ReactiveProperty<string>();
        private ReactiveProperty<string> _maxCountCartdrige = new ReactiveProperty<string>();


        public WeaponViewModel(IWeapon weapon)
        {
            _weapon = weapon;
            _weapon.Fire += InvokeShoot;
            _weapon.Reload += InvokeReload;
            _weapon.Scope += InvokeScope;
            _weapon.ChangeCartridge += OnChangeCartridge;
            _weapon.ChangeMaxCountCartridge += OnChangeMaxCountCartridge;
        }

        private void InvokeShoot()
        {
            Shoot?.Invoke();
        }
        private void InvokeScope()
        {
            Scope?.Invoke();
        }

        private void InvokeReload()
        {
            Reload?.Invoke();
        }
        
        private void OnChangeCartridge(int currentCartridge)
        {
            _currentCartridge.Value = currentCartridge.ToString();
        }
        private void OnChangeMaxCountCartridge(int maxCount)
        {
            _maxCountCartdrige.Value = maxCount.ToString();
        }
        public ReactiveProperty<string> GetCurrentNumberCartridge()
        {
            return _currentCartridge;
        }
        public ReactiveProperty<string> GetMaxCartridge()
        {
            return _maxCountCartdrige;
        }

        public void Dispose()
        {            
            _weapon.Fire -= InvokeShoot;
            _weapon.Reload -= InvokeReload;
            _weapon.Scope -= InvokeScope;
            _weapon.ChangeCartridge -= OnChangeCartridge;
            _weapon.ChangeMaxCountCartridge -= OnChangeMaxCountCartridge;
        }
    }
}