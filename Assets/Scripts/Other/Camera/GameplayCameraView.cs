using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using ViewModel;


[RequireComponent(typeof(Camera))]
public class GameplayCameraView : MonoBehaviour, IView<IViewModel>
{
    public Camera Camera { get; private set; }

    public IViewModel ViewModel { get; }
    public void Init()
    {
        Camera = GetComponent<Camera>();
    }
}
