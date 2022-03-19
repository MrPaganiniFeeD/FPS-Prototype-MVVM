using Zenject;

namespace Other.Fabric
{
    public class FabricsInitializable : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindFabricsInitializable();
        }

        private void BindFabricsInitializable()
        { 
            Container.BindInterfacesTo<FabricsInitializable>().FromInstance(this).AsSingle();
        }
        
        public void Initialize()
        {
                
        }
    }
}