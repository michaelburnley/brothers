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


    //	public float speed = 100f;
	// public float max_speed = 200f;
	// public float acceleration = 10f;
	// public float deceleration = 5f;

	// public float mod_speed = 0f;
	// public float mod_max_speed = 0f;
	// public float mod_acceleration = 0f;
	// public float mod_deceleration = 0f;