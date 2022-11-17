using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunUIWidget : MonoBehaviour
{
    [SerializeField] private List<Image> bulletIcons;
    [SerializeField] private TextMeshProUGUI label;

    private void UpdateLabel(GunCartridge cartridge) => label.text = cartridge.TotalRemainingBullets + "/" + cartridge.TotalBullets;

    public void OnGunUpdate(GunCartridge cartridge)
    {
        UpdateLabel(cartridge);
        int bulletCartridge = cartridge.RemainingBullets;

        for (int i = 0; i < bulletIcons.Count; i++)
        {
            bulletIcons[cartridge.CartridgeCapacity-i-1].color = bulletCartridge > i ? Color.white : Color.gray;
        }
    }
}
