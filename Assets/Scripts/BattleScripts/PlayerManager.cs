using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理决心移动的类
/// </summary>
public class PlayerManager : MonoBehaviour {

    private Rigidbody2D rb;

    private bool isCollidUp = false;
    private bool isCollidDown = false;
    private bool isCollidLeft = false;
    private bool isCollidRight = false;

    // 是否已跳跃
    public bool isJump = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        if (v == 0)
            isJump = true;
        float h = Input.GetAxis("Horizontal");
        if (!isJump) {
            transform.Translate(new Vector2(0, 0.3f) * Time.deltaTime * 6);
        }
        rb.AddForce(new Vector2(h,0)*Time.deltaTime*40);
        print("v:"+v);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        
        isCollidUp = false;
        isCollidRight = false;
        isCollidDown = false;
        isCollidLeft = false;
        if (collision.collider.CompareTag("upCollider"))
            isCollidUp = true;
        if (collision.collider.CompareTag("downCollider")) {
            isCollidDown = true;
            isJump = false;
        }
        if (collision.collider.CompareTag("leftCollider"))
            isCollidLeft = true;
        if (collision.collider.CompareTag("rightCollider"))
            isCollidRight = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isCollidUp = false;
        isCollidRight = false;
        isCollidDown = false;
        isCollidLeft = false;
    }
}
