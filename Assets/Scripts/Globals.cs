using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    static public List<PlayerState> states = new List<PlayerState>();
    static public PlayerState state = new PlayerState();
    static private int score = 0;
    static private int scene = 0;
    static private bool countdown_active = false;
    static private float background_speed;
    static private Vector3 boss_position = new Vector3(0.76f, 8.28f, -1.1f);

    static public PlayerState State {
        get {
            return state;
        }
    } 

    static public int Score {
        get {
            return score;
        }
    }

    static public int Scene {
        get {
            return scene;
        }
    }

    static public float BackgroundSpeed {
        get {
            return background_speed;
        }
        
        set {
            background_speed = value;
        }
    }


    static public void ChangeScore(int scoreChange) {
        score += scoreChange;
        EventManager.TriggerEvent(Message.CHANGE_SCORE);
    }

    static public void BossEncounter(GameObject boss) {
        Vector3 boss_position = new Vector3(0.76f, 8.28f, -1.1f);
        GameObject.Instantiate(boss, position, Quaternion.identity);
        EventManager.TriggerEvent(Message.BOSS_ENCOUNTER);
    }


    static public void AddUpgrade(UpgradeData up) {
        state.Upgrades(up);
        EventManager.TriggerEvent(Message.UPGRADE_ADDED);
    }

    static public void PlayerHealth(int healthChange) {
        int upgrade_count = state.Upgrades().Count;

        if (state.Shield > 0) {
            state.Shield = state.Shield - 1;
            EventManager.TriggerEvent(Message.SHIELD_DAMAGE);
        } else if (upgrade_count > 0) {
            state.Downgrade();
        } else {
            state.Health = state.Health - 1;
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
