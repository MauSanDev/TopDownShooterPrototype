using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GunDatabase gunDatabase;
    [SerializeField] private ShooterNPC player = null;
    [SerializeField] private GunUIWidget cartridgeWidget = null;

    [SerializeField] private string initialGun = "default";

    private void Start()
    {
        GunRegistry gunRegistry = gunDatabase.GetGunWithID(initialGun);
        player.GunStack.AddGun(gunRegistry.gunPrefab, true);
        player.Gun.Cartridge.OnGunUpdate += cartridgeWidget.OnGunUpdate;
    }
}
