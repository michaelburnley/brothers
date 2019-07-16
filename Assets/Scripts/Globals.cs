using System.Collections;
using System.Collections.Generic;

public static class Globals
{

    static private int score = 0;
    static private int playerHealth = 1;
    static private List<Upgrade> upgrades = new List<Upgrade>();

    static private int scene = 0;

    static public int Score() {
        return score;
    }

    static public int Health() {
        return playerHealth;
    }

    static public List<Upgrade> Upgrades() {
        return upgrades;
    }

    static public int Scene() {
        return scene;
    }

    static public void ChangeScore(int scoreChange) {
        score += scoreChange;
        EventManager.TriggerEvent(Events.message.CHANGE_SCORE);
    }

    static public void AddUpgrade(Upgrade up) {
        upgrades.Add(up);
        EventManager.TriggerEvent(Events.message.UPGRADE_ADDED);
    }

    static public void PlayerHealth(int healthChange) {
        playerHealth += healthChange;
        EventManager.TriggerEvent(Events.message.CHANGE_HEALTH);
    }

    static public void NextScene() {
        scene++;
        EventManager.TriggerEvent(Events.message.NEXT_SCENE);
    }

    static public void GameOver() {
        EventManager.TriggerEvent(Events.message.GAME_OVER);
    }
}
