using UnityEngine;
using ViewModel.Physics;

namespace View.Physics
{
    public class RaycastDetectorView : MonoBehaviour, IRaycastDetectorView
    {
        public IDesiredViewModel ViewModel { get; private set; }
        
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IDesiredViewModel desiredViewModel)
        {
            ViewModel = desiredViewModel;
        }
        public bool TryGetModelType<T>(out T searchableType)
        {
            return ViewModel.TryCheckTypeModel(out searchableType);
        }

        public void SetHit(RaycastHit hit)
        {
            
        }
    }
}