using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public double interval = 1;

    double nextTick = 0;
    Vector3 direction;

    LineRenderer line_renderer;

    void Start() {
        line_renderer = GetComponent<LineRenderer>();
        nextTick = Time.time;
        direction = new Vector3(1,0,0);
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


        var count = line_renderer.positionCount;
        var positions = new Vector3[count];
        line_renderer.GetPositions(positions);

        var new_positions = new Vector3[count + 1];

        for(int i = 0; i < count; ++i) {
            new_positions[i] = positions[i];
        }
        new_positions[count] = new_positions[count-1] + direction;

        line_renderer.positionCount = count + 1;
        line_renderer.SetPositions(new_positions);
    }
}
