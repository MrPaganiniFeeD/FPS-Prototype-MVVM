using System;
using Model.Environment.Explosive;
using ViewModel.Physics;

namespace ViewModel.Environment
{
    public class ExplosionViewModel : IExplodingViewModel
    {
        public event Action Explosion;
        
        private IExploding _exploding;
        
        public ExplosionViewModel(IExploding exploding)
        {
            _exploding = exploding;
            _exploding.Explosion += OnExploding;
        }

        private void OnExploding()
        {
            Explosion?.Invoke();
        }
        
        public void Dispose()
        {
            _exploding.Explosion -= OnExploding;
        }
    }
}