public static class Globals
{

    static private int score = 0;
    static private int playerHealth = 1;

    static public int Score() {
        return score;
    }

    static public int Health() {
        return playerHealth;
    }

    static public void ChangeScore(int scoreChange) {
        score += scoreChange;
        EventManager.TriggerEvent(Events.message.CHANGE_SCORE);
    }

    static public void PlayerHealth(int healthChange) {
        playerHealth += healthChange;
        EventManager.TriggerEvent(Events.message.CHANGE_HEALTH);
    }

    static public void GameOver() {
        EventManager.TriggerEvent(Events.message.GAME_OVER);
    }
}
