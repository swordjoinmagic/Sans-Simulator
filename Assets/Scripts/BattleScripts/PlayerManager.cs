using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理决心移动的类
/// </summary>
public class PlayerManager : MonoBehaviour {

    public HPView hpView;

    private Rigidbody2D rb;

    private float time = 0;

    // 是否已跳跃
    public bool isJump = false;
    // 是否正在移动
    private bool isMove = false;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        if (v == 0)
            isJump = true;
        float h = Input.GetAxis("Horizontal");
        if (!isJump && v > 0) {
            transform.Translate(new Vector2(0, 0.3f) * Time.deltaTime * 6);
        } else if (v < 0) {
            transform.Translate(-new Vector2(0, 0.2f) * Time.deltaTime * 6);
        }
        rb.AddForce(new Vector2(h,0)*Time.deltaTime*8000);

        if (v == 0 && h == 0 && Math.Round(rb.velocity.x,1)==0 && Math.Round(rb.velocity.y, 1) == 0) {
            isMove = false;
        } else {
            isMove = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision) {

        if (collision.collider.CompareTag("downCollider")) {
            isJump = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        // 判断蓝色骨头
        if ((collision.CompareTag("blueBone") && isMove) || (collision.CompareTag("OrangeBone") && !isMove)) {
            print("在蓝色骨头中移动");
            // 每隔0.1s触发一次
            time += Time.deltaTime;
            if (time > 0.02f) {
                time = 0;
            } else if (time < 0.02f) {
                return;
            }

            if (hpView.BindingContext.HP.Value > 0)
                hpView.BindingContext.HP.Value -= 1;
        }
    }
}
