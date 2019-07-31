using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private Text speechBox;
    private string speech;
    private string[] text_lines;
    private float timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (speech.Length > 0) {
            text_lines = speech.Split('\n');
            speechBox.text = text_lines[0];
        }
    }

    public string Speech {
        set {
            speech = value;
        }
    }
}
