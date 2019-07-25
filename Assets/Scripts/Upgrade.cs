using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private UpgradeData upgradeData; // 1

    private Text upgradeText;
    void Start()
    {
        upgradeText = GameObject.Find("UpgradeText").GetComponent<Text>();
        GetComponent<Image>().sprite = upgradeData.Icon;
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
