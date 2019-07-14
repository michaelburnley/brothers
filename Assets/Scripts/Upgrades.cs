using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade {
    public float cost = 0;
    public float rarity = 1;
    public Sprite sprite;

    public virtual void UpdateStats(Player player) {

    }
}

public class Booster : Upgrade {
    private float mod_speed = 10.5f;

    public override void UpdateStats(Player player) {
        player.mod_speed += mod_speed;
    }
}