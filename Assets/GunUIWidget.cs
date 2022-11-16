using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunUIWidget : MonoBehaviour
{
    [SerializeField] private GunHandler gunHandler;
    [SerializeField] private List<Image> bulletIcons;
    [SerializeField] private TextMeshProUGUI label;
    
    private void UpdateLabel() => label.text = gunHandler.Cartridge.TotalRemainingBullets + "/" + gunHandler.Cartridge.TotalBullets;

    void Update()
    {
        UpdateLabel();
        int bulletCartridge = gunHandler.Cartridge.RemainingBullets;

        for (int i = 0; i < bulletIcons.Count; i++)
        {
            bulletIcons[gunHandler.Cartridge.CartridgeCapacity-i-1].color = bulletCartridge > i ? Color.white : Color.gray;
        }
    }
}
