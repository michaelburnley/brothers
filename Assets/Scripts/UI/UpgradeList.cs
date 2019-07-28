using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeList : MonoBehaviour
{
    [HideInInspector]
    private UpgradeData[] upgrades;

    [SerializeField]
    private GameObject imagePrefab;
    // Start is called before the first frame update
    void Start()
    {
        upgrades = Globals.state.Upgrades().ToArray();
        processUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void processUpgrades() {
        for (int i = 0; i < upgrades.Length; i++) {
            GameObject upgrade_image = GameObject.Instantiate(imagePrefab, new Vector3(i*2.0f, 0, 0), Quaternion.identity);
            upgrade_image.GetComponent<Image>().sprite = upgrades[i].Icon;
            upgrade_image.transform.SetParent(transform, false);
        }
    }
}
