using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private BossData bossData;
    private string[] text_lines;
    private SpriteRenderer renderer;
    protected int health;
    private GameObject conversation_canvas;

    private void OnEnable() {
        
    }

    private void OnDisable() {
        
    }

    private void Awake() {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = bossData.Sprite;
        health = bossData.Health;
        conversation_canvas = GameObject.Find("UI Elements").gameObject.transform.GetChild(1).gameObject;
        Debug.Log(conversation_canvas);
        conversation_canvas.gameObject.SetActive(true);
        conversation_canvas.GetComponent<Conversation>().Speech = bossData.SpeechText;
    }

    void Start()
    {

    }


    void Update()
    {
        Movement();
    }

    private void Movement() {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        
    }

    private void OnDestroy() {
        
    }

}
