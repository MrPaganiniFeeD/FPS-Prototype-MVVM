using System;
using System.Threading.Tasks;
using Other.Pool.Mono;
using UnityEditorInternal;
using UnityEngine;
using View.ImpactHit;
using ViewModel;
using Random = UnityEngine.Random;

namespace View.Projectile
{
    public class ProjectileImpactHitView : MonoBehaviour, IView<IViewModel>
    {
        [SerializeField] private Transform _poolImpactContainer;

        [Header("Impact Effect Prefabs")]
        public BloodImpact _bloodImpactPrefab;
        public MetalImpact  _metalImpactPrefab;
        public DirtImpact _dirtImpactPrefab;
        public ConcreteImpact _concreteImpactPrefab;

        public IViewModel ViewModel { get; }

        private PoolMono<BloodImpact> _bloodImpactPool;
        private PoolMono<MetalImpact> _metalImpactPool;
        private PoolMono<DirtImpact> _dirtImpactPool;
        private PoolMono<ConcreteImpact> _concreteImpactPool;

        public void Awake()
        {
            _bloodImpactPool = new PoolMono<BloodImpact>(
                _bloodImpactPrefab, 1, true, null);
            
            _metalImpactPool = new PoolMono<MetalImpact>(
                _metalImpactPrefab, 1, true, null);
            
            _dirtImpactPool = new PoolMono<DirtImpact>(
                _dirtImpactPrefab, 1, true, null);
            
            _concreteImpactPool = new PoolMono<ConcreteImpact>(
                _concreteImpactPrefab, 5, true, null);
        }

        public void Init() { }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Blood"))
            {
                var bloodImpact = _bloodImpactPool.GetFreeElement();
                bloodImpact.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
                gameObject.SetActive(false);
            }
            if (collision.transform.CompareTag("Metal"))
            {
                var metalImpact = _metalImpactPool.GetFreeElement();
                metalImpact.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
                gameObject.SetActive(false); ;
            }
            if (collision.transform.CompareTag("Dirt"))
            {
                var dirtImpact = _dirtImpactPool.GetFreeElement();
                dirtImpact.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
                gameObject.SetActive(false);
            }
            if (collision.transform.CompareTag("Concrete"))
            {
                var position = transform.position;
                var concreteImpact = _concreteImpactPool.GetFreeElement();
                concreteImpact.Play(position,
                    Quaternion.LookRotation(collision.contacts[0].normal),
                    1000);
                gameObject.SetActive(false);
            }
        }
        
    }
}