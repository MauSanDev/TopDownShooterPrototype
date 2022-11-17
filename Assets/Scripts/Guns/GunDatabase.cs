using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunDatabase", menuName = "Guns/New Database")]
public class GunDatabase : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private List<GunRegistry> gunRegistries = new List<GunRegistry>();

    private Dictionary<string, GunRegistry> registriesDic = new Dictionary<string, GunRegistry>();

    public GunRegistry GetGunWithID(string id)
    {
        if (!registriesDic.ContainsKey(id))
        {
            Debug.LogError($"The gun with ID {id} doesn't exist!");
            return registriesDic["default"];
        }

        return registriesDic[id];
    }

    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        registriesDic.Clear();
        foreach (GunRegistry gunRegistry in gunRegistries)
        {
            registriesDic[gunRegistry.gunId] = gunRegistry;
        }
    }
}

[Serializable]
public class GunRegistry
{
    [SerializeField] public string gunId;
    [SerializeField] public GunHandler gunPrefab;
    [SerializeField] public GunUIWidget gunUiWidget;
}