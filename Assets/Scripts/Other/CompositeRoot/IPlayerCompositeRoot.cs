using System.Collections;
using System.Collections.Generic;
using Other.Inventory;
using Player;
using UnityEngine;

public interface IPlayerCompositeRoot
{
    PlayerModel PlayerModel { get; }
    PlayerStats PlayerStats { get; }
    ICameraRotation CameraRotation { get; }

    TransformableViewModel TransformableViewModel { get; }
    
    PlayerView PlayerView { get; }
    GameplayCameraView GameplayCameraView { get; }
    InventoryCompositeRoot InventoryCompositeRoot { get; }
}
