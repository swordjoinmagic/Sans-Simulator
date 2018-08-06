using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour {
    private Transform player;
    public new Collider2D collider2D;

    private void Start() {

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            if (player.position.y >= transform.position.y) {
                collider2D.enabled = true;
            } else {
                collider2D.enabled = false;
            }
        }
    }
}
