using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utilities
{

    static public GameObject Create(GameObject created_obj, GameObject parent_obj) {
        GameObject temp = GameObject.Instantiate(created_obj, parent_obj.transform.position, parent_obj.transform.rotation);
        BulletHandler script = temp.GetComponent<BulletHandler>();
        Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), parent_obj.GetComponent<Collider2D>());
        // script.
        return temp;
    }

}
