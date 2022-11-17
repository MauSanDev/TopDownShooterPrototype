using System;
using System.Collections.Generic;
using UnityEngine;

public class GunStackHandler : MonoBehaviour
{
    [SerializeField] private List<GunHandler> gunStack = new List<GunHandler>();
    [SerializeField] private Transform gunContainer = null;

    private void Start()
    {
        if (gunStack.Count >= 1)
        {
            SetupGun(0);
        }
    }

    public GunHandler CurrentGun { get; private set; }
    
    public void AddGun(GunHandler gunPrefab, bool set)
    {
        GunHandler instance = Instantiate(gunPrefab, gunContainer.transform);
        gunStack.Add(instance);
        Debug.Log($"Added {gunPrefab.name} to the Player");

        if (set)
        {
            SetupGun(gunStack.Count -1);
        }
    }
    
    public void SetupGun(int gunIndex)
    {
        if (CurrentGun != null)
        {
            CurrentGun.gameObject.SetActive(false);
        }
        
        CurrentGun = gunStack[gunIndex];
        CurrentGun.gameObject.SetActive(true);
        Debug.Log($"Selected {CurrentGun.name} on the Player");
    }

    [Serializable]
    public class StackedGun
    {
        public string gunId;
        public GunHandler gunObject;
    }
}
