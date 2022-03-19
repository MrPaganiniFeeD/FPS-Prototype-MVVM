using CompositeRoot.UI;
using UnityEngine;
using Zenject;

namespace Other.Infostructures
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private DamageHitUIContainer _damageHitUIContainer;
        
        
        public override void InstallBindings()
        {
            BindMainCanvas();
            BindDamageHitUIContainer();
        }
        private void BindDamageHitUIContainer()
        { 
            Container.Bind<DamageHitUIContainer>().FromInstance(_damageHitUIContainer).AsSingle();
        }
        private void BindMainCanvas()
        {
            Container.Bind<Canvas>().FromInstance(_mainCanvas).AsSingle();
        }
    }
}