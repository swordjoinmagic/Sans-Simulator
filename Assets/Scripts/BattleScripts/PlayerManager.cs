using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private Rigidbody2D rb;

    private bool isCollidUp = false;
    private bool isCollidDown = false;
    private bool isCollidLeft = false;
    private bool isCollidRight = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0) {
            if (isCollidUp && v > 0)
                v = 0;
            if (isCollidDown && v < 0)
                v = 0;
            if (isCollidLeft && h < 0)
                h = 0;
            if (isCollidRight && h > 0)
                h = 0;
            transform.Translate(new Vector3(h, v, 0) * Time.deltaTime * 3);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        
        isCollidUp = false;
        isCollidRight = false;
        isCollidDown = false;
        isCollidLeft = false;
        if (collision.collider.CompareTag("upCollider"))
            isCollidUp = true;
        if (collision.collider.CompareTag("downCollider"))
            isCollidDown = true;
        if (collision.collider.CompareTag("leftCollider"))
            isCollidLeft = true;
        if (collision.collider.CompareTag("rightCollider"))
            isCollidRight = true;
    }
}
