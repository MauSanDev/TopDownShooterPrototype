﻿using UnityEngine;

public class GunEmptyState : AbstractGunState
{
    public override void UpdateState(float deltaTime) { }

    public override void RefreshState() { }

    public override void OnActionExecuted()
    {
        if (Gun.Cartridge.HasBulletsToLoad)
        {
            Gun.TransitionToState(Gun.GunStates.Reloading);
        }
        else
        {
            Debug.LogWarning("You don't have more shots!");
        }
    }

    public override void OnActionReleased()
    {
        throw new System.NotImplementedException();
    }
}