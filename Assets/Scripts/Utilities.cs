using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Utilities
{
    static public GameObject Create(GameObject created_obj, GameObject parent_obj) {
        GameObject temp = GameObject.Instantiate(created_obj, parent_obj.transform.position, parent_obj.transform.rotation);
        if (temp.transform.childCount > 0) {
            Debug.Log("Multiple children." + temp.transform.childCount);
            for (int i = 0; i < temp.transform.childCount; i++) {
                GameObject child = temp.transform.GetChild(i).gameObject;
                Physics2D.IgnoreCollision(child.GetComponent<Collider2D>(), parent_obj.GetComponent<Collider2D>());
            }
        } else {
            Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), parent_obj.GetComponent<Collider2D>());
        }
        return temp;
    }

    static public GameObject Create(GameObject created_obj, GameObject parent_obj, Vector3 path) {
        GameObject temp = GameObject.Instantiate(created_obj, parent_obj.transform.position, parent_obj.transform.rotation);
        BulletHandler script = temp.GetComponent<BulletHandler>();
        Physics2D.IgnoreCollision(temp.GetComponent<Collider2D>(), parent_obj.GetComponent<Collider2D>());
        return temp;
    }
}

static class Extensions {
    public static T Pop<T>(this List<T> list) {
        int index = list.Count - 1;
        T r = list[index];
        list.RemoveAt(index);
        return r;
    }

    public static T Pop<T>(this List<T> list, int index) {
        T r = list[index];
        list.RemoveAt(index);
        return r;
    }

    public static List<T> Unshift<T>(this List<T> list, T item) {
        list.Insert(0, item);
        return list;
    }
}