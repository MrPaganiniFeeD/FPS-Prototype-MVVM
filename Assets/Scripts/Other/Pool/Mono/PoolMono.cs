using System;
using System.Collections.Generic;
using System.Linq;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Other.Pool.Mono
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        private T _prefab;
        private bool _autoExpand;
        private Transform _container;
        private DiContainer _diContainer;
        private List<T> _pool;
        private int _size;
        public PoolMono(T prefab, int size, bool autoExpand,Transform container)
        {
            _prefab = prefab;
            _autoExpand = autoExpand;
            _container = container;
            _size = size;
            CreatePool(_size);
        }
        [Inject]
        public void Init(DiContainer diContainer)
        {
            Debug.Log(diContainer);
            _diContainer = diContainer;
            CreatePool(_size);
        }
        private void CreatePool(int size)
        {
            _pool = new List<T>();

            for (var i = 0; i < size; i++)
                CreateObject();
        }
        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool.Where(mono => mono.gameObject.activeInHierarchy == false))
            {
                mono.gameObject.SetActive(true);
                element = mono;
                return true;
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (_autoExpand)
            {
                _size++;
                return CreateObject(true);
            }
            throw new Exception($"There is no free elements in poo; of {typeof(T)}");
        }
        public void DeletePool()
        {
            _pool.Clear();
        }

        public void DestroyAllElements()
        {
            foreach (var mono in _pool)
            {
                Object.Destroy(mono.gameObject);
            }
            _pool.Clear();
        }
    }
}