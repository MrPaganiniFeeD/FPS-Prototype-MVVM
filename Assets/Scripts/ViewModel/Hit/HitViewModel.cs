using UniRx;
using UnityEngine;

namespace ViewModel.Hit
{
    public class HitViewModel : IHitViewModel
    {
        private ReactiveProperty<RaycastHit> _hit = new ReactiveProperty<RaycastHit>();

        public ReactiveProperty<RaycastHit> GetRaycastHit()
        {
            return _hit;
        }
        public void SetHit(RaycastHit hit)
        {
            _hit.Value = hit;
        }
        public void Dispose()
        {
        }
    }
}