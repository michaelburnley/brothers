using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{

    static private int score = 0;
    static private int playerHealth = 1;
    static private int scene = 0;
    static private List<UpgradeData> upgrades = new List<UpgradeData>();
    static private bool countdown_active = false;
    static private float background_speed;


    static public int Score {
        get {
            return score;
        }
    }

    static public int Health {
        get {
            return playerHealth;
        }
    }

    static public List<UpgradeData> Upgrades {
        get {
            return upgrades;
        }
    }

    static public int Scene {
        get {
            return scene;
        }
    }

    static public float BackgroundSpeed {
        set {
            background_speed = value;
        }

        get {
            return background_speed;
        }
    }

    static public void ChangeScore(int scoreChange) {
        score += scoreChange;
        EventManager.TriggerEvent(Message.CHANGE_SCORE);
    }

    static public void AddUpgrade(UpgradeData up) {
        upgrades.Add(up);
        EventManager.TriggerEvent(Message.UPGRADE_ADDED);
    }

    static public void PlayerHealth(int healthChange) {
        playerHealth += healthChange;
        EventManager.TriggerEvent(Message.CHANGE_HEALTH);
    }

    static public void NextScene() {
        scene++;
        Debug.Log(scene);
        EventManager.TriggerEvent(Message.NEXT_SCENE);
    }

    static public void GameOver() {
        EventManager.TriggerEvent(Message.GAME_OVER);
    }

    static public void CountDown() {
        countdown_active = true;
        EventManager.TriggerEvent(Message.COUNTDOWN);
    }

    static public void ExitGame() {
        EventManager.TriggerEvent(Message.EXIT_GAME);
        Debug.Log("Exiting game.");
        Application.Quit();
    }
}
