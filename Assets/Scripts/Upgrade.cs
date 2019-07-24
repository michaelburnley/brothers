using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private UpgradeData upgradeData; // 1
    // Start is called before the first frame update
    private Text upgradeText;
    void Start()
    {
        upgradeText = GameObject.Find("UpgradeText").GetComponent<Text>();
        GetComponent<Image>().sprite = upgradeData.Icon;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(upgradeData.Description);
    }

    public virtual void UpdateStats(Player player) {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData) {
        string data = upgradeData.UpgradeName + "\n" + upgradeData.Description;
        upgradeText.text = data;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        upgradeText.text = "";
    }

    // private void OnMouseDown() {
    //     Globals.AddUpgrade(upgradeData);
    //     Globals.NextScene();
    // }
}
