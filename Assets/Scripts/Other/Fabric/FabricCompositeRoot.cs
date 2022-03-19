using CompositeRoot;
using CompositeRoot.Weapon;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using Zenject;

namespace Other.Fabric
{
    public class FabricCompositeRoot : IFabricCompositeRoot
    {

        private DiContainer _diContainer;

        public FabricCompositeRoot(DiContainer diContainer)
        {
            Debug.Log(diContainer);
            _diContainer = diContainer;
        }

        public void Load()
        {
            Debug.Log(_diContainer);
        }

        public T CreateRoot<T>(GameObject prefab, Vector3 position, Quaternion quaternion, Transform transform)
            where T : IRoot
        {
            var gameObject = _diContainer.InstantiatePrefab(prefab, position, quaternion, transform);
            gameObject.transform.localRotation = Quaternion.identity;
            var root = gameObject.GetComponent<T>();
            if (root == null) return default(T);
            root.Init();
            return root;
        }
    }
}