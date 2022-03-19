using UniRx;
using UnityEngine;

namespace ViewModel.Hit
{
    public interface IHitViewModel : IViewModel
    {
        ReactiveProperty<RaycastHit> GetRaycastHit();
        void SetHit(RaycastHit hit);
    }
}