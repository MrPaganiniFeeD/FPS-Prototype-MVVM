using Model.Physics;

namespace ViewModel.Physics
{
    public interface IDesiredViewModel : IViewModel
    {
        bool TryCheckTypeModel<T>(out T searchingModel);
    }
}