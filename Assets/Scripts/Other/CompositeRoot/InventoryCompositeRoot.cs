using System.ComponentModel;
using CompositeRoot;
using CompositeRoot.Weapon;
using Other.Fabric;
using Other.Inventory;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class InventoryCompositeRoot : MonoBehaviour, IRoot, IInitializable
{
    [SerializeField] private GameObject _galil;
    [SerializeField] private Transform _weaponSlot;
    
    private IFabricCompositeRoot _fabricCompositeRoot;
    
    private IInventory _inventory;
    public IInventory Inventory => _inventory;

    [Inject]
    public void Construct(IFabricCompositeRoot fabricCompositeRoot)
    {
        _fabricCompositeRoot = fabricCompositeRoot;
    }


    public void Init()
    {
        //Model
        _inventory = new Inventory();
        
        //viewModel
        
        
        //View
    }

    public void Initialize()
    {
        Debug.Log("Initialize");
        _fabricCompositeRoot.Load();

        var galil = _fabricCompositeRoot.CreateRoot<IWeaponRoot>(_galil, _weaponSlot.position, Quaternion.identity, _weaponSlot);
        _inventory.BindToFirsSlot(galil.Weapon);
    }
}
