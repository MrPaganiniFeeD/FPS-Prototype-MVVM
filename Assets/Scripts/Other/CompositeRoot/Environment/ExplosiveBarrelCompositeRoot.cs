using System;
using System.Collections;
using System.Collections.Generic;
using CompositeRoot;
using DefaultNamespace;
using Model;
using Model.Environment.Explosive;
using Player.Stats;
using Player.Weapon.ViewModel;
using UnityEngine;
using View.Physics;
using ViewModel.Environment;
using ViewModel.Physics;

public class ExplosiveBarrelCompositeRoot : MonoBehaviour, IRoot
{
    [SerializeField] private int _health;
    [SerializeField] private ExplosionBarrelView _explosionBarrelView;
    [SerializeField] private RaycastDetectorView _raycastDetectorView;

    private ExplosionBarrel _explosion;

    private IExplodingViewModel _explodingViewModel;
    private IDesiredViewModel _desiredViewModel;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        //model
        _explosion = new ExplosionBarrel(transform.position, new RotationLocal(0,0,0), new Health("Health", _health));

        //viewModel
        _explodingViewModel = new ExplosionViewModel(_explosion);
        _desiredViewModel = new DesiredViewModel(_explosion);
        
        //view
        _explosionBarrelView.Init(_explodingViewModel);
        _raycastDetectorView.Init(_desiredViewModel);
    }
}
