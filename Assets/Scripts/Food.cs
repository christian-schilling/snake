using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Start() {
        Respawn();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Snake snake = other.gameObject.transform.parent.gameObject.GetComponent<Snake>();
        if (snake == null) { return; }
        snake.Feed();

        Respawn();
    }

    void Respawn() {
        for (int i = 0; i< 1000;++i) {
            var spawn_at = new Vector3((int)Random.Range(-3.5f,4), (int)Random.Range(-4,4),0);
            var hits = Physics2D.OverlapCircleAll(spawn_at, 1.0f);
            if (0 == hits.Length) {
                transform.position = spawn_at;
                return;
            }
        }
    }
}
