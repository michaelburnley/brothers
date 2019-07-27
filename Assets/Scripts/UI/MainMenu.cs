using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings() {
        Debug.Log("Finding Child object");
        GameObject settings_menu = this.transform.parent.Find("SettingsMenu").gameObject;
        this.gameObject.SetActive(false);
        settings_menu.gameObject.SetActive(true);
    }

    public void ExitGame() {
        Globals.ExitGame();
    }

    public void Back() {
        this.gameObject.SetActive(false);
        GameObject main_menu = this.transform.parent.Find("MainMenu").gameObject;
        main_menu.gameObject.SetActive(true);
    }
}
