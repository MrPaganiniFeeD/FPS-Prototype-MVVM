using Player.PlayerInputView;
using UnityEngine;

namespace CompositeRoot
{
    public class PlayerMovementRoot : MonoBehaviour
    {
        [SerializeField] private PlayerMovementInputView playerMovementInputView;
        [SerializeField] private Camera _camera;
    }
}