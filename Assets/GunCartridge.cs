using UnityEngine;

public class GunCartridge
{
    private int bulletsPerCartridge = 0;
    private int totalBullets = 0;
    
    private int currentBullets = 0;
    
    public bool HasBulletsToShot => currentBullets > 0;
    public bool HasBulletsToLoad => totalBullets > 0;

    public bool IsCartridgeFull => currentBullets == bulletsPerCartridge || totalBullets == 0;
    
    public GunCartridge(int bulletsPerCartridge, int totalBullets)
    {
        this.bulletsPerCartridge = bulletsPerCartridge;
        this.totalBullets = totalBullets;
        Reload();
    }

    public void Consume(int amount = 1)
    {
        currentBullets = Mathf.Max(0, currentBullets - amount);
    }

    public void Reload()
    {
        if (currentBullets == bulletsPerCartridge || totalBullets == 0)
        {
            return;
        }

        int diff = Mathf.Min(totalBullets, bulletsPerCartridge - currentBullets);
        totalBullets -= diff;
        currentBullets = Mathf.Min(diff,bulletsPerCartridge);
    }
}