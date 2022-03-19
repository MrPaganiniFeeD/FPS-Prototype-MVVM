using UnityEngine;
using ViewModel.Physics;

namespace View.Physics
{
    public interface IRaycastDetectorView
    {
        bool TryGetModelType<T>(out T searchableType);
        void SetHit(RaycastHit hit);
    }
}