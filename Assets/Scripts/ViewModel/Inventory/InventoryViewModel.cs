using Other.Inventory;

namespace ViewModel.Inventory
{
    public class InventoryViewModel : IInventoryViewModel
    {
        private IInventory _inventory;
        
        
        public InventoryViewModel(IInventory inventory)
        {
            _inventory = inventory;
            _inventory.ChangeCurrentWeapon += OnChangeCurrentWeapon;
        }

        private void OnChangeCurrentWeapon(IWeapon weapon)
        {
            
        }


        public void Dispose()
        {
        }
    }
}