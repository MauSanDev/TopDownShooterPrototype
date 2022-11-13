using UnityEngine;

public class GunEmptyState : AbstractGunState
{
    public override void Update(float deltaTime) { }

    protected override void RefreshState() { }

    public override void Shot()
    {
        Debug.LogWarning(Gun.Cartridge.HasBulletsToLoad ? "You need to recharge!" : "You don't have more shots!");
    }
}