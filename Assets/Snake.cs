using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public double interval = 1;
    public Transform prefab;

    double nextTick = 0;
    Vector3 direction;

    LineRenderer line_renderer;

    void Start() {
        line_renderer = GetComponent<LineRenderer>();
        nextTick = Time.time;
        direction = new Vector3(1,0,0);
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity, transform);
    }

    void Update()
    {

        if (Input.GetKey("w")) { direction = new Vector3(0,1,0); }
        if (Input.GetKey("s")) { direction = new Vector3(0,-1,0); }
        if (Input.GetKey("a")) { direction = new Vector3(-1,0,0); }
        if (Input.GetKey("d")) { direction = new Vector3(1,0,0); }

        if(Time.time > nextTick) {
            Debug.Log("Tick");
            nextTick += interval;
        }
        else {
            return;
        }


        foreach(Transform child in transform) {
            Debug.Log(child.position);
        }

        var lastChild = transform.GetChild(transform.childCount - 1);

        Instantiate(prefab, lastChild.position + direction, Quaternion.identity, transform);

        Destroy (GetComponent<Transform> ().GetChild (0).gameObject);


    }
}
