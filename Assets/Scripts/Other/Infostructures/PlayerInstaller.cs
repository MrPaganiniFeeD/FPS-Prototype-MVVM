using CompositeRoot;
using CompositeRoot.Weapon;
using Other.Fabric;
using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPosition;


    [SerializeField] private Transform _spawnWeaponTransform;
    [SerializeField] private GameObject _galil;
    
    private PlayerRoot _playerRoot;
    private InventoryCompositeRoot _inventoryCompositeRoot;
    private IFabricCompositeRoot _fabricCompositeRoot;
    
    public override void InstallBindings()
    { 
        BindFabricCompositeRoot();
        BindPlayerCompositeRoot();
        BindInventoryCompositeRoot();
        BindGameplayCameraView();
    }

    private void BindPlayerInstaller()
    {
        Container.BindInterfacesTo<PlayerInstaller>().FromInstance(this).AsSingle();
    }
    private void BindPlayerCompositeRoot()
    {
         _playerRoot = Container
            .InstantiatePrefabForComponent<PlayerRoot>(_playerPrefab,
            _spawnPosition.position, Quaternion.identity, null);
         _playerRoot.Init();
        
        Container
            .Bind<IPlayerCompositeRoot>()
            .To<PlayerRoot>()
            .FromInstance(_playerRoot)
            .AsSingle();
    }
    private void BindInventoryCompositeRoot()
    { 
        Container.BindInterfacesTo<InventoryCompositeRoot>().FromInstance(_playerRoot.InventoryCompositeRoot).AsSingle();
    }

    private void BindGameplayCameraView()
    {
        Container.Bind<GameplayCameraView>().FromInstance(_playerRoot.GameplayCameraView).AsSingle();
    }
    private void BindFabricCompositeRoot()
    {
        Container
            .Bind<IFabricCompositeRoot>()
            .To<FabricCompositeRoot>()
            .FromNew()
            .AsSingle()
            .WithArguments(Container);
    }
    
}