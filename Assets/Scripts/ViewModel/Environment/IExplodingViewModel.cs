using System;

namespace ViewModel.Environment
{
    public interface IExplodingViewModel : IViewModel
    {
        event Action Explosion;
    }
}