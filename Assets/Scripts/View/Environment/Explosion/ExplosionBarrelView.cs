using System;
using System.Threading.Tasks;
using UnityEngine;
using View;
using ViewModel.Environment;

namespace DefaultNamespace
{
    public class ExplosionBarrelView : MonoBehaviour, IView<IExplodingViewModel>
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Collider _collider;
        [SerializeField] private MeshRenderer _mesh;
        [SerializeField] private Light _light;
        [SerializeField] private int _lifeTime;
        [SerializeField] private int _lightTime;
        public IExplodingViewModel ViewModel { get; private set; }
        
        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IExplodingViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Explosion += OnExplosion;
        }
        private void OnExplosion()
        {
            _particle.Play();
            _audioSource.Play();
            
            _mesh.enabled = false;
            _collider.enabled = false;
            
            _light.enabled = true;
            LifeTimeBarrel();
            LifeTimeLight();
        }

        private void SwitchModel()
        {
            
        }

        private async void LifeTimeBarrel()
        {
            await Task.Delay(_lifeTime);
            Destroy(gameObject);
        }

        private async void LifeTimeLight()
        {
            await Task.Delay(_lightTime);
            _light.enabled = false;
        }

        private void OnDestroy()
        {
            ViewModel.Explosion -= OnExplosion;
        }
    }
}