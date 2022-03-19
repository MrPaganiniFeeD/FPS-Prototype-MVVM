using Player.Weapon.ViewModel;
using View;

namespace Player.Weapon.View
{
    public class WeaponView : IView<IWeaponViewModel>
    {
        public IWeaponViewModel ViewModel { get; private set; }
        public void Init() { throw new System.NotImplementedException(); }

        public void Init(IWeaponViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}