using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float restartDelay = 5f;            // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

    private void OnEnable() {
        EventManager.StartListening(Message.GAME_OVER, _GameOver);
    }

    private void OnDisable() {
        EventManager.StopListening(Message.GAME_OVER, _GameOver);
    }

    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

    private void _GameOver() {
        anim.SetTrigger("GameOver");
    }
}