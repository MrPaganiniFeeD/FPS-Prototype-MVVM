using System;
using Player.Weapon.ViewModel;
using UnityEngine;
using View;

namespace Player.Weapon.View.Auidio
{
    public class WeaponAudioView : MonoBehaviour, IView<IWeaponViewModel>
    {
        [SerializeField] private AudioSource _audioSource;
        
        public IWeaponViewModel ViewModel { get; private set; }


        public void Init() { throw new System.NotImplementedException(); }
        public void Init(IWeaponViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Shoot += OnShoot; 
        }

        private void OnShoot()
        {
            _audioSource.Play();
        }

        private void OnDestroy()
        {
            ViewModel.Shoot -= OnShoot;
        }
    }
}