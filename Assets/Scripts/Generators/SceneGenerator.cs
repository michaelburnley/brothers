using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject {
        public float position_x;
        public float position_y;
        public float position_z;
        public string name;
        public string tag;
        public int layer;
        public Color color;
        public bool flip_x;
        public bool flip_y;

        public SceneObject (GameObject obj) {

            SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();

            position_x = obj.transform.position.x;
            position_y = obj.transform.position.y;
            position_z = obj.transform.position.z;
            name = obj.name;
            tag = obj.tag;
            layer = obj.layer;
            color = sprite.color;
            flip_x = sprite.flipX;
            flip_y = sprite.flipY;
        }
}

public class ParentObject {
    public List<SceneObject> elements;
    public string name;

    public ParentObject (GameObject obj, List<SceneObject> object_elements) {
        name = obj.name;
        elements = object_elements;
    }
}

public class Scene {
    public List<ParentObject> scenes;
}

public class SceneGenerator
{
    private GameObject foreground = GameObject.Find("Foreground");
    private GameObject background_far = GameObject.Find("Background (far)");
    private GameObject middleground = GameObject.Find("Middleground");
    private GameObject low_visibility = GameObject.Find("Low Visibility");
    private GameObject background_close = GameObject.Find("Background (close)");
    private List<ParentObject> objects = new List<ParentObject>();

    private ParentObject GenerateObjects (GameObject obj) {
        List<SceneObject> elements = new List<SceneObject>();
        foreach (Transform child in obj.transform) {
            SceneObject serializedObject = new SceneObject(obj);
            elements.Add(serializedObject);
        }
        ParentObject parent = new ParentObject(obj, elements);
        return parent;
    }

    public string GenerateJSON () {
        objects.Add(GenerateObjects(foreground));
        objects.Add(GenerateObjects(background_far));
        objects.Add(GenerateObjects(middleground));
        objects.Add(GenerateObjects(low_visibility));
        objects.Add(GenerateObjects(background_close));
        return JsonUtility.ToJson(objects);
    }
}