using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    private List<State> states = new List<State>();
    private List<UpgradeData> upgrades = new List<UpgradeData>();
    private float bullet_speed = 20f;

    private int health = 1;
    private int shield = 0;
    private int missile = 0;
    private float speed = 50;
    private float max_speed = 200f;
	private float acceleration = 10f;
	private float deceleration = 5f;
    private float fire_rate = 0;

    public float FireRate {
        get {
            return fire_rate;
        }

        set {
            fire_rate = value;
        }
    }

    public float Speed {
        get {
            return speed;
        }

        set {
            speed = value;
        }
    }

    public float MaxSpeed {
        get {
            return max_speed;
        }
    }

    public float Acceleration {
        get {
            return acceleration;
        }
    }

    public float Deceleration {
        get {
            return deceleration;
        }
    }

    public int Health {
        get {
            return health;
        }

        set {
            health = value;
        }
    }

    public int Missile {
        get {
            return missile;
        }

        set {
            missile = value;
        }
    }

    public int Shield {
        get {
            return shield;
        }

        set {
            shield = value;
        }
    }

    public List<State> State() {
        return states;
    }

    public List<State> States(State updated_state) {
        return states;
    }

    public List<UpgradeData> Upgrades() {
        return upgrades;
    }

    public List<UpgradeData> Upgrades(UpgradeData upgrade) {
        upgrades.Add(upgrade);
        return upgrades;
    }

    public UpgradeData Downgrade() {
        return upgrades.Pop();
    }

    public List<State> ChangeState(State updated_state) {
        return states;
    }

}

public class State {
    public enum shield {
        NO_SHIELD,
        HIGHLY_DAMAGED_SHIELD,
        DAMAGED_SHIELD,
        FULL_SHIELD,
    }

    public enum booster {
        BOOSTER_1,
        BOOSTER_2,
        BOOSTER_3,
    }
}
