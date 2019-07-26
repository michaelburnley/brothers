using UnityEngine;
using UnityEngine.UI;

public class CountdownMeter: MonoBehaviour {

    Animator anim;
    Image bar;               
    private void OnEnable() {
        EventManager.StartListening(Message.COUNTDOWN, Countdown);
    }

    private void OnDisable() {
        EventManager.StopListening(Message.COUNTDOWN, Countdown);
    }

    public void Countdown() {

    }
}