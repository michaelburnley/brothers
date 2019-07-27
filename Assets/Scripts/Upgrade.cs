using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [HideInInspector]
    public UpgradeData upgradeData;
    [SerializeField]
    private Text upgradeText;

    private void Update()
    {
        if (upgradeData) {
            GetComponent<Image>().sprite = upgradeData.Icon;
            Debug.Log(upgradeData.Icon);
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        string data = upgradeData.UpgradeName + "\n" + upgradeData.Description;
        upgradeText.text = data;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        upgradeText.text = "";
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        Globals.AddUpgrade(upgradeData);
        Debug.Log("Added upgrade.");
    }
}