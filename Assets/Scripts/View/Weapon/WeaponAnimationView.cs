using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player.Weapon.ViewModel;
using UnityEngine;
using View;


[RequireComponent(typeof(Animator))]
public class WeaponAnimationView : MonoBehaviour, IView<IWeaponViewModel>
{
    [SerializeField] private Animator _animator;
    private Transform _transform;
    public IWeaponViewModel ViewModel { get; private set; }

    private static readonly int Fire = Animator.StringToHash("Fire");
    private static readonly int Reloading = Animator.StringToHash("Reloading");
    private Vector3 _startPosition;

    public void Init() { throw new System.NotImplementedException(); }
    public void Init(IWeaponViewModel viewModel)
    {
        _transform = GetComponent<Transform>();
        _startPosition = _transform.position;
        ViewModel = viewModel;
        ViewModel.Shoot += OnShoot;
        ViewModel.Reload += OnReload;
    }

    private void OnReload()
    {
        _animator.SetTrigger(Reloading);
    }
    private void OnShoot()
    {
        _animator.SetTrigger(Fire);
    }
    private void OnDisable()
    {
        ViewModel.Shoot -= OnShoot;
        ViewModel.Reload -= OnReload;
    }
}
