using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Snake snake = other.gameObject.transform.parent.gameObject.GetComponent<Snake>();
        if (snake == null) { return; }
        snake.Kill();
    }
}
