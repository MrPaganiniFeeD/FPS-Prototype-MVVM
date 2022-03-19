using System;
using System.Collections;
using System.Collections.Generic;
using CompositeRoot;
using Player.Weapon.Model.OtherWeapon;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class SceneBootstrapper : MonoBehaviour
{
    [SerializeField] private GalilRoot _galilRoot;
    [SerializeField] private PlayerRoot _player;
    [SerializeField] private Transform _spawnPosition;

    private DiContainer _diContainer;
    private GameplayCameraView _gameplayCameraView;
    [Inject]
    public void Construtcot(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }
    private void Start()
    {
        BootstrapPlayer();
      //  BootstrapGalil();
    }

    private void BootstrapGalil()
    {
        var galil = _diContainer.InstantiatePrefab(_galilRoot, new Vector3(0, 0, 0), quaternion.identity, null);
        var galilRoot = galil.GetComponent<GalilRoot>();
        galilRoot.Init();
    }

    private void BootstrapPlayer()
    {
        var player = _diContainer.InstantiatePrefab(_player, _spawnPosition.position, Quaternion.identity, null);
        var playerRoot = player.GetComponent<PlayerRoot>();
        _gameplayCameraView = player.GetComponent<GameplayCameraView>();
        _diContainer.Bind<GameplayCameraView>().FromInstance(_gameplayCameraView).AsSingle();
        if (playerRoot != null)
        {
            playerRoot.Init();
        }
    }
}
