using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Globals.AddUpgrade(upgradeData);
        Debug.Log("Added upgrade.");
    }
}