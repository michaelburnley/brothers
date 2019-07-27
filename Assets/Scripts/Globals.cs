using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{

    static private int score = 0;
    static private int scene = 0;
    static private List<UpgradeData> upgrades = new List<UpgradeData>();
    static private bool countdown_active = false;
    static private float background_speed;
    static private int playerHealth = 1;
    static private int shield = 0;


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

    static public int Shield {
        get {
            return shield;
        }

        set {
            shield = value;
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

    static public void BossEncounter(GameObject boss) {
        Vector3 position = new Vector3(0.76f, 8.28f, 1);
        GameObject.Instantiate(boss, position, Quaternion.identity);
        EventManager.TriggerEvent(Message.BOSS_ENCOUNTER);
    }


    static public void AddUpgrade(UpgradeData up) {
        upgrades.Add(up);
        EventManager.TriggerEvent(Message.UPGRADE_ADDED);
    }

    static public void PlayerHealth(int healthChange) {
        if (shield > 0) {
            shield--;
            EventManager.TriggerEvent(Message.SHIELD_DAMAGE);
        } else if (upgrades.Count > 0) {
           upgrades.RemoveAt(upgrades.Count - 1); 
        } else {
            playerHealth += healthChange;
        }
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
