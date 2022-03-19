using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;
using ViewModel;
using Debug = UnityEngine.Debug;

namespace View.ImpactHit
{
    public class ConcreteImpact : MonoBehaviour, IView<IViewModel>
    {
        public IViewModel ViewModel { get; }
        public void Init() { throw new System.NotImplementedException(); }
        public async void Play(Vector3 position, Quaternion rotation, int lifeTime)
        {
            transform.rotation = rotation;
            transform.position = position;
            gameObject.SetActive(true);
            await Task.Delay(lifeTime);
            gameObject.SetActive(false);
        }
    }
}