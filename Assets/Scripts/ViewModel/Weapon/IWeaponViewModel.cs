using System;
using UniRx;
using ViewModel;

namespace Player.Weapon.ViewModel
{
    public interface IWeaponViewModel : IViewModel
    {
        event Action Shoot;
        event Action Reload;
        event Action Scope;

        ReactiveProperty<string> GetCurrentNumberCartridge();
        ReactiveProperty<string> GetMaxCartridge();
    }
}