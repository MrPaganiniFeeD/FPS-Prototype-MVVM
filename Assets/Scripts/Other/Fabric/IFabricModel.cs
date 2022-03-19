using Model;

namespace Other.Fabric
{
    public interface IFabricModel
    {
        T CreateModel<T>() where T : IModel;
    }
}