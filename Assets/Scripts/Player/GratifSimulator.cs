using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于给角色模拟重力
/// </summary>
public class GratifSimulator : MonoBehaviour {
    // 下降过程中的最大速度
    public float maxSpeed = 5;
    // 重力加速度
    public float g = 9.8f;

    private new Rigidbody2D rigidbody2D;

    // 当前速度
    public float vlocity = 0f;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        float deltaVlocity = Time.deltaTime * g;
        vlocity = Mathf.Clamp(vlocity+deltaVlocity,0,maxSpeed);
        rigidbody2D.velocity = new Vector2(0,-vlocity);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        // 碰撞时速度置0
        if (collision.collider.CompareTag("downCollider")) {
            vlocity = 0;

        }
    }

    public void OnCollisionStay2D(Collision2D collision) {
        // 碰撞时速度置0
        if (collision.collider.CompareTag("downCollider")) {
            vlocity = 0;

        }
    }
}
