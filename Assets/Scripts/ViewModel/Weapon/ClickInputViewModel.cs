using ViewModel;

namespace Player.Weapon.ViewModel
{
    public class ClickInputViewModel : IClickInputViewModel
    {
        private PlayerShooting _playerShooting;
        public ClickInputViewModel(PlayerShooting playerShooting)
        {
            _playerShooting = playerShooting;
        }
        public void LeftClick(float deltaTime)
        {
            _playerShooting.Shoot(deltaTime);
        }
        public void RightClick(float deltaTime)
        {
            _playerShooting.Aim(deltaTime);
        }

        public void Dispose()
        {
        }
    }
}