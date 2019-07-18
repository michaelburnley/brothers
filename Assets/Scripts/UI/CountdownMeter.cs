using UnityEngine;
using UnityEngine.UI;

public class CountdownMeter: MonoBehaviour {

    Animator anim;
    Image bar;               
    private void OnEnable() {
        EventManager.StartListening(Events.message.COUNTDOWN, Countdown);
    }

    private void OnDisable() {
        EventManager.StopListening(Events.message.COUNTDOWN, Countdown);
    }

    public void Countdown() {

    }
}