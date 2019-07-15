using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float restartDelay = 5f;            // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

    private void OnEnable() {
        EventManager.StartListening(Events.message.GAME_OVER, _GameOver);
    }

    private void OnDisable() {
        EventManager.StopListening(Events.message.GAME_OVER, _GameOver);
    }

    void Awake ()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }

    private void _GameOver() {
        // ... tell the animator the game is over.
        anim.SetTrigger ("GameOver");

        // .. increment a timer to count up to restarting.
        // restartTimer += Time.deltaTime;

        // // .. if it reaches the restart delay...
        // if(restartTimer >= restartDelay)
        // {
        //     // .. then reload the currently loaded level.
        //     Application.LoadLevel(Application.loadedLevel);
        // }
    }
}