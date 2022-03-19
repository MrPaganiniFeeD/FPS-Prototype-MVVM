using UnityEngine;
using UnityEngine.Serialization;

namespace Infostruct.Data
{
    [CreateAssetMenu(fileName = "New Setting", menuName = "Settings/Create PlayerSettings", order = 51)]

    public class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [SerializeField] private float sensitivityX;
        [SerializeField] private float sensitivityY;

        [SerializeField] private float _speed;
        
        public float SensitivityX => sensitivityX;
        public float SensitivityY => sensitivityY;
        public float Speed => _speed;
    }
}