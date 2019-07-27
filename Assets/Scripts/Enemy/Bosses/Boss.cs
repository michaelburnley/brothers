using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private BossData bossData;
    private string[] text_lines;

    void Start()
    {
        text_lines = bossData.SpeechText.Split('\n');
    }


    void Update()
    {
        
    }


}
