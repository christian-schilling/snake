using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Snake snake = other.gameObject.transform.parent.gameObject.GetComponent<Snake>();
        if (snake == null) { return; }
        snake.Feed();

        transform.position = new Vector3(Random.Range(-3.5f,4), Random.Range(-4,4),0);
    }
}
