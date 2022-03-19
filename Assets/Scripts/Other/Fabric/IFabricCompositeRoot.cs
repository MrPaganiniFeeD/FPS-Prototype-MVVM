using CompositeRoot;
using UnityEngine;

namespace Other.Fabric
{
    public interface IFabricCompositeRoot
    {
        void Load();

        T CreateRoot<T>(GameObject prefab, Vector3 position, Quaternion quaternion, Transform transform)
            where T : IRoot;
    }
}