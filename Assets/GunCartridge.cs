﻿using UnityEngine;

public class GunCartridge
{
    private AmountStack cartridgeBullets;
    private AmountStack totalBullets;
    
    public bool HasBulletsToShot => cartridgeBullets.RemainingAmount > 0;
    public bool HasBulletsToLoad => cartridgeBullets.RemainingAmount > 0;

    public bool IsCartridgeFull => cartridgeBullets.IsFull || totalBullets.IsEmpty;
    
    public GunCartridge(int bulletsPerCartridge, int totalBullets)
    {
        this.totalBullets = new AmountStack(totalBullets);
        cartridgeBullets = new AmountStack(bulletsPerCartridge);
        Reload();
    }

    public void Consume(int amount = 1)
    {
        cartridgeBullets.Substract(amount);
        Debug.Log($"Remaining :: Cartridge: {cartridgeBullets} - Total {totalBullets}");
    }

    public void Reload()
    {
        int toLoad = totalBullets.Substract(cartridgeBullets.Difference);
        cartridgeBullets.Add(toLoad);
    }
}

public class AmountStack
{
    private int remainingAmount = 0;
    private int originalAmount = 0;

    public AmountStack(int totalAmount)
    {
        originalAmount = totalAmount;
        Refill();
    }

    public void Refill() => remainingAmount = originalAmount;
    public void Add(int amount) => remainingAmount = Mathf.Min(originalAmount, remainingAmount + amount);

    public int RemainingAmount => remainingAmount;
    public int TotalCapacity => originalAmount;
    public int Difference => originalAmount - remainingAmount;

    public bool IsFull => remainingAmount == originalAmount;
    public bool IsEmpty => remainingAmount == 0;

    public override string ToString() => $"{remainingAmount}/{originalAmount}";

    public int Substract(int amount)
    {
        int toReturn = Mathf.Min(remainingAmount, amount);
        remainingAmount -= toReturn;

        return toReturn;
    }
}