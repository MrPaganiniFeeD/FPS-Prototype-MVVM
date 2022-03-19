using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using ViewModel.Damageble;

public class DamageHitAudioView : MonoBehaviour, IView<IDamageableViewModel>
{
    [SerializeField] private AudioSource _audioSource;
    
    public IDamageableViewModel ViewModel { get; private set; }
    public void Init() { throw new System.NotImplementedException(); }
    public void Init(IDamageableViewModel viewModel)
    {
        ViewModel = viewModel;
        ViewModel.TakingDamage += OnTakingDamage;
    }
    private void OnTakingDamage()
    {
        _audioSource.Play();
    }
    private void OnDestroy()
    {
        ViewModel.TakingDamage -= OnTakingDamage;
    }
}
