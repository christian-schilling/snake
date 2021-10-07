using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Transform prefab;
    public int length = 1;
    public Game game;

    double nextTick = 0;
    Vector3 direction;

    void Start()
    {
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
            nextTick += game.interval;

            var lastChild = transform.GetChild(transform.childCount - 1);
            Instantiate(prefab, lastChild.position + direction, Quaternion.identity, transform);
        }

        if (transform.childCount > length) {
            Destroy (GetComponent<Transform> ().GetChild (0).gameObject);
        }
    }

    public void Kill()
    {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }

        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity, transform);
    }

    public void Feed()
    {
        length += 2;
    }
}
