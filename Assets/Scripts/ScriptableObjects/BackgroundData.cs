using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Background", menuName = "Background", order = 51)]
public class BackgroundData : ScriptableObject
{
    [SerializeField]
    private float scrolling_speed;

    [SerializeField]
    private float backgroundPosition;

    [SerializeField]
    private float offset;

    [SerializeField]
    private Sprite background;

    public float Speed {
        get {
            return scrolling_speed;
        }
    }

    public float Position {
        get {
            return backgroundPosition;
        }
    }

    public float Offset {
        get {
            return offset;
        }
    }

    public Sprite Background {
        get {
            return background;
        }
    }

}
