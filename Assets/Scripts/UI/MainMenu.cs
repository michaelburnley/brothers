using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip backSFX;
    public AudioClip clickSFX;
    public AudioClip music;

    private void Start() {
        SoundManager.instance.PlayMusic(music);
    }

    public void PlayGame() {
        SoundManager.instance.PlaySingle(clickSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings() {
        Debug.Log("Finding Child object");
        SoundManager.instance.PlaySingle(clickSFX);
        GameObject settings_menu = this.transform.parent.Find("SettingsMenu").gameObject;
        this.gameObject.SetActive(false);
        settings_menu.gameObject.SetActive(true);
    }

    public void ExitGame() {
        SoundManager.instance.PlaySingle(clickSFX);
        Globals.ExitGame();
    }

    public void Back() {
        SoundManager.instance.PlaySingle(backSFX);
        this.gameObject.SetActive(false);
        GameObject main_menu = this.transform.parent.Find("MainMenu").gameObject;
        main_menu.gameObject.SetActive(true);
    }
}
