using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events {
    public enum message {
        CHANGE_SCORE,
        CHANGE_HEALTH,
        GAME_OVER,
        NEXT_SCENE,
        UPGRADE_ADDED,
    };
}