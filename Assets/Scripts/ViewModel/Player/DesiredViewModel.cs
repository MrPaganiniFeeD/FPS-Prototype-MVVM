using Model.Physics;
using ViewModel.Physics;

namespace Player.Weapon.ViewModel
{
    public class DesiredViewModel : IDesiredViewModel
    {
        private IDesiredModel _model;
        
        public DesiredViewModel(IDesiredModel model)
        {
            _model = model;
        }
        public bool TryCheckTypeModel<T>(out T searchingModel)
        {
            if (_model is T unknown)
            {
                searchingModel = unknown; 
                return true;
            }
            searchingModel = default;
            return false;
        }

        public void Dispose()
        {
        }
    }
}