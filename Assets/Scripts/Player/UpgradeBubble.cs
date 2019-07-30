using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBubble : MonoBehaviour
{

    // Should bounce around screen for the the duration of the timer
    // Once timer is hit, bubble pops and the upgrade falls straight down

    public float timer;
    private UpgradeData upgradeData;
    private bool bubblePopped = false;
    private float timeToDestroy = 10f;
    private GameObject upgrade;
    private GameObject bubble;
    private SpriteRenderer upgradeRenderer;
    private SpriteRenderer bubbleRenderer;

    private void Awake() {
        upgrade = this.gameObject.transform.GetChild(0).gameObject;
        upgradeRenderer = upgrade.GetComponent<SpriteRenderer>(); 
        bubble = this.gameObject.transform.GetChild(1).gameObject;
        bubbleRenderer = bubble.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (upgradeData) {
            Movement();
            Timer();
        }
    }

    private void Movement() {

    }

    private void Timer() {
        timer += Time.deltaTime;
        if (timer > timeToDestroy) {
            bubblePop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "player") {
            bubblePop();
            Globals.AddUpgrade(upgradeData);
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "barrier") {
            if (bubblePopped == false) {
                transform.position = Vector3.Reflect(transform.position, Vector3.right);
            } else {
                Destroy(this.gameObject);                
            }
        }
    }

    private void bubblePop() {
        bubble.SetActive(false);
    }

    private void OnDestroy() {
        Debug.Log("Play animation");
    }

    public void SetDataObject(UpgradeData data) {
        upgradeData = data;
    }
}
