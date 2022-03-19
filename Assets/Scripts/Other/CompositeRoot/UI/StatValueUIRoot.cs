using System;
using System.Collections;
using System.Collections.Generic;
using CompositeRoot;
using Player;
using Player.Model.Stats.StatViewModel;
using UnityEngine;
using View;
using ViewModel;
using Zenject;

public class StatValueUIRoot : MonoBehaviour, IRoot
{
    [SerializeField] private TextView _healthTextView;
    [SerializeField] private TextView _armorTextView;

    private ITextViewModel _healthViewModel;
    private ITextViewModel _armorViewModel;

    private PlayerStats _playerStats;

    [Inject]
    public void Constructor(IPlayerCompositeRoot playerCompositeRoot)
    {
        Debug.Log(playerCompositeRoot);
        _playerStats = playerCompositeRoot.PlayerStats;
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        //model


        //ViewModel
        _healthViewModel = new StatViewModel(_playerStats.Health);
        _armorViewModel = new StatViewModel(_playerStats.Armor);

        //View
        _healthTextView.Init(_healthViewModel);
        _armorTextView.Init(_armorViewModel);
    }
}